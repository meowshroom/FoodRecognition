function [ colorNameVector, compressedImage ] = getColorNameVector_Meow( image, mode, mask, w2c )
% Image : input image
% mask : foreground pixels(1) and bg pixels(0) corrs. to image
% mode 0 ( FAST ): you will get colorNameVector only, compressedImage is all zero
% mode 1 (SLOW): you will get both colorNameVector and compressedImage

if mode == 1
	compressedImage = im2c(image,w2c,-1) / 255;
else
	compressedImage = zeros( size(image) );
end

% No mask : All the pixels are foreground
if isempty(mask)
	mask = ones( size(image) );
end

%% �έpColor Name Vector
colorNames = im2c(image,w2c,0);
colorNames = colorNames .* mask; %�I���ܦ�0�A�e��1~11

colorNameVector = zeros(11,1);
for colorI = 1 : 11
	colorNameVector(colorI) = sum( sum( colorNames==colorI ) ); %�ݩ��Color Name�A�åB���e��
end
colorNameVector = colorNameVector / norm(colorNameVector);
