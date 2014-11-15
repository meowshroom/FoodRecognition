function [image_fg] =  drawColorNameVectorPie_Meow( colorNameVector, compressedImage, mask )

figure('units','normalized','outerposition',[0 0 1 1]);

%% 畫原圖
subplot(1,3,1);
imshow( compressedImage );

%% 畫原圖的前景
subplot(1,3,2);
mask3 = repmat( mask, [1, 1, 3] );
image_fg = compressedImage .* mask3;
imshow( image_fg );

%%畫圓餅圖
%避免圓餅圖忽略0，造成該欄位空缺，導致設定顏色時出錯
colorNameVectorToDisplay = colorNameVector;
colorNameVectorToDisplay(colorNameVectorToDisplay==0)=1e-9;

%%顯示圓餅圖
rgbmatrix = getBasicColors_Meow() ;

subplot(1,3,3);
pieHandle = pie(colorNameVectorToDisplay);
for colorI = 1 : 11
	% Apply the colors we just generated to the pie chart.
	set( pieHandle(colorI*2-1), 'FaceColor', rgbmatrix(colorI,:) );
	set( pieHandle(colorI*2), 'String', sprintf( '%.3f %%',colorNameVector(colorI)*100/sum(colorNameVector) ) );
end