function [ foregroundGuess, labelGuess ] = kmeansGuess_Meow( image, nColors, fgRatioMin, fgRatioMax  )
% Input-image: an RGB image
% Input-nColors: wish k color centroids in k-means color clustering
% Input-foreGroundRatio: approximated ( area of fg / area of image )
% This file will use kmeans to eliminate the most background-like color.
% Output foregroundGuess : Input image with background removed.
% Output labelGuess : Output label map guess with 0=bg, 1=fg
% kmeansGuess在顏色分布單純的影像上就已經可以給出良好的去背結果
cform = makecform('srgb2lab');

%Mapping RGB to Lab color space
image_Lab = applycform(image,cform);%RGB to LAB
image_ab = double( image_Lab(:,:,2:3) );%AB of LAB
%image_ab(:,:,1) = image_ab(:,:,1) .* double(image_Lab(:,:,1));
%image_ab(:,:,2) = image_ab(:,:,2) .* double(image_Lab(:,:,1));
[ h, w, c ] = size( image_ab );
imgArea = h*w;%面積

% Reshape and do kmeans
image_ab_reshaped = reshape( image_ab, [h*w, 2] );
warning ('off','all');
[idx, ~] = kmeans( image_ab_reshaped, nColors, 'distance', 'sqEuclidean', 'Replicates',10, 'EmptyAction', 'drop' );
warning ('on','all');
pixel_labels = reshape( idx, [h,w] );

% 把被歸類為3種顏色的pixel，各自集合成3張圖片
% 另外3張圖片，分別是去掉某一種顏色的區域
images_with_1_color = cell(1,nColors); %只有某一種顏色的圖片(暫時棄用)
images_without_1_color = cell(1,nColors); %只缺少某一種顏色的圖片
rgb_label = repmat(pixel_labels,[1 1 3]); %每個pixel屬於哪個center(RGB共同對應)

for k = 1: nColors
	color = image;
	color(rgb_label ~= k) = 0;%只剩這個顏色;
	images_with_1_color{k} = color;
	images_without_1_color{k} = image-color;%只剔除這個顏色
end

%找images_without_1_color裡面的圖片，
[ fgLabel, bgLabel ] = getPredefinedLabel_Meow( image ); %Predefined Labels
shouldBeForeground = uint8(fgLabel);
shouldBeBackground = uint8(bgLabel);

%% Color k 「前景假設面積」/「背景假設面積」，此值越大越有可能是前景顏色
foregroundIndexes = uint8(pixel_labels) .* shouldBeForeground; %只留下在前景區域的pixel_label
backgroundIndexes = uint8(pixel_labels) .* shouldBeBackground; %只留下在背景區域的pixel_label

fg_bg_ratio = zeros( nColors, 1 ); 
for k = 1: nColors
	%計算前景數量
	fg_Qt = length( foregroundIndexes(foregroundIndexes==k) );
	%計算背景數量
	bg_Qt = length( backgroundIndexes(backgroundIndexes==k) );
	%計算前景背景比例
	fg_bg_ratio(k) = fg_Qt / bg_Qt;
end
%排序:前景背景比
[~, mostColorIndex] = sort(fg_bg_ratio, 'descend'); %bgColorIndex:哪個color index被歸類為background
foregroundGuess = uint8( zeros( h, w, 3 ) ); %目前猜測的前景圖片(每經過一個iter，就加上一種顏色)
labelGuess = zeros( h, w ); %目前猜測的前景index(每經過一個iter，就加上一個index顏色的分布)

for k = 1 : nColors %從 前景背景比 高 到 前景背景比 低 (依序對每個顏色群)
	
	%先預覽，還不真的加上去
	thisLabelGuess = labelGuess; 
	thisLabelGuess(pixel_labels==mostColorIndex(k))=1; %加上「一種顏色」(的Index)
	
	%如果加了這個顏色之後，Foreground面積比例>Foreground面積比例Max，就不要加
	if length(thisLabelGuess(thisLabelGuess==1)) > fgRatioMax*imgArea;
		break;
	end
	
	%如果沒事，就加上去
	labelGuess = thisLabelGuess;
	foregroundGuess = foregroundGuess + images_with_1_color{mostColorIndex(k)}; %加上一種顏色(的原色)

	%加了這個顏色之後，Foreground面積比例>Foreground面積比例Min，就停止
	if length(labelGuess(labelGuess==1)) > fgRatioMin*imgArea
		break;
	end
	
end


%產生標籤
%labelGuess = zeros(h, w);
%labelGuess(pixel_labels~=bgColorIndex) = 1;

%Foreground 轉成 double
foregroundGuess = double(foregroundGuess)/255;


end

