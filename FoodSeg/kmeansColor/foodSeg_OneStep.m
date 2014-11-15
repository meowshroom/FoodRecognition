function [ foregroundGuess, foregroundRefined, labelRefined ] = foodSeg_Meow( image, nColors )
% Input: an RGB image
% Output: 

[h0, w0, ~] = size(image); %原始影像大小
smallImage = rotateAndResizeImage_Meow( image );
[h1, w1, ~] = size(smallImage); %縮小後的影像大小


%使用kmeans貓咪
[ foregroundGuess, labelGuess ] = kmeansGuess( smallImage, nColors );
repmat( labelGuess, [1,1,3]);

%使用segRefine
labelRefined = segRefine(thisImg, labelGuess);
labelRefined = imfill(labelRefined, 'holes');%填洞洞
labelRefined3 = repmat(labelRefined, [1,1,3]);
thisImg = double(thisImg)/255;

foregroundRefined = thisImg .* labelRefined3;



end