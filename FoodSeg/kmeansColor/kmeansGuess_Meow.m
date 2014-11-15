function [ foregroundGuess, labelGuess ] = kmeansGuess_Meow( image, nColors, fgRatioMin, fgRatioMax  )
% Input-image: an RGB image
% Input-nColors: wish k color centroids in k-means color clustering
% Input-foreGroundRatio: approximated ( area of fg / area of image )
% This file will use kmeans to eliminate the most background-like color.
% Output foregroundGuess : Input image with background removed.
% Output labelGuess : Output label map guess with 0=bg, 1=fg
% kmeansGuess�b�C�������ª��v���W�N�w�g�i�H���X�}�n���h�I���G
cform = makecform('srgb2lab');

%Mapping RGB to Lab color space
image_Lab = applycform(image,cform);%RGB to LAB
image_ab = double( image_Lab(:,:,2:3) );%AB of LAB
%image_ab(:,:,1) = image_ab(:,:,1) .* double(image_Lab(:,:,1));
%image_ab(:,:,2) = image_ab(:,:,2) .* double(image_Lab(:,:,1));
[ h, w, c ] = size( image_ab );
imgArea = h*w;%���n

% Reshape and do kmeans
image_ab_reshaped = reshape( image_ab, [h*w, 2] );
warning ('off','all');
[idx, ~] = kmeans( image_ab_reshaped, nColors, 'distance', 'sqEuclidean', 'Replicates',10, 'EmptyAction', 'drop' );
warning ('on','all');
pixel_labels = reshape( idx, [h,w] );

% ��Q�k����3���C�⪺pixel�A�U�۶��X��3�i�Ϥ�
% �t�~3�i�Ϥ��A���O�O�h���Y�@���C�⪺�ϰ�
images_with_1_color = cell(1,nColors); %�u���Y�@���C�⪺�Ϥ�(�Ȯɱ��)
images_without_1_color = cell(1,nColors); %�u�ʤ֬Y�@���C�⪺�Ϥ�
rgb_label = repmat(pixel_labels,[1 1 3]); %�C��pixel�ݩ����center(RGB�@�P����)

for k = 1: nColors
	color = image;
	color(rgb_label ~= k) = 0;%�u�ѳo���C��;
	images_with_1_color{k} = color;
	images_without_1_color{k} = image-color;%�u�簣�o���C��
end

%��images_without_1_color�̭����Ϥ��A
[ fgLabel, bgLabel ] = getPredefinedLabel_Meow( image ); %Predefined Labels
shouldBeForeground = uint8(fgLabel);
shouldBeBackground = uint8(bgLabel);

%% Color k �u�e�����]���n�v/�u�I�����]���n�v�A���ȶV�j�V���i��O�e���C��
foregroundIndexes = uint8(pixel_labels) .* shouldBeForeground; %�u�d�U�b�e���ϰ쪺pixel_label
backgroundIndexes = uint8(pixel_labels) .* shouldBeBackground; %�u�d�U�b�I���ϰ쪺pixel_label

fg_bg_ratio = zeros( nColors, 1 ); 
for k = 1: nColors
	%�p��e���ƶq
	fg_Qt = length( foregroundIndexes(foregroundIndexes==k) );
	%�p��I���ƶq
	bg_Qt = length( backgroundIndexes(backgroundIndexes==k) );
	%�p��e���I�����
	fg_bg_ratio(k) = fg_Qt / bg_Qt;
end
%�Ƨ�:�e���I����
[~, mostColorIndex] = sort(fg_bg_ratio, 'descend'); %bgColorIndex:����color index�Q�k����background
foregroundGuess = uint8( zeros( h, w, 3 ) ); %�ثe�q�����e���Ϥ�(�C�g�L�@��iter�A�N�[�W�@���C��)
labelGuess = zeros( h, w ); %�ثe�q�����e��index(�C�g�L�@��iter�A�N�[�W�@��index�C�⪺����)

for k = 1 : nColors %�q �e���I���� �� �� �e���I���� �C (�̧ǹ�C���C��s)
	
	%���w���A�٤��u���[�W�h
	thisLabelGuess = labelGuess; 
	thisLabelGuess(pixel_labels==mostColorIndex(k))=1; %�[�W�u�@���C��v(��Index)
	
	%�p�G�[�F�o���C�⤧��AForeground���n���>Foreground���n���Max�A�N���n�[
	if length(thisLabelGuess(thisLabelGuess==1)) > fgRatioMax*imgArea;
		break;
	end
	
	%�p�G�S�ơA�N�[�W�h
	labelGuess = thisLabelGuess;
	foregroundGuess = foregroundGuess + images_with_1_color{mostColorIndex(k)}; %�[�W�@���C��(�����)

	%�[�F�o���C�⤧��AForeground���n���>Foreground���n���Min�A�N����
	if length(labelGuess(labelGuess==1)) > fgRatioMin*imgArea
		break;
	end
	
end


%���ͼ���
%labelGuess = zeros(h, w);
%labelGuess(pixel_labels~=bgColorIndex) = 1;

%Foreground �ন double
foregroundGuess = double(foregroundGuess)/255;


end

