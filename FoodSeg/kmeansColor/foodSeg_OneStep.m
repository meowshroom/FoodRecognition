function [ foregroundGuess, foregroundRefined, labelRefined ] = foodSeg_Meow( image, nColors )
% Input: an RGB image
% Output: 

[h0, w0, ~] = size(image); %��l�v���j�p
smallImage = rotateAndResizeImage_Meow( image );
[h1, w1, ~] = size(smallImage); %�Y�p�᪺�v���j�p


%�ϥ�kmeans�߫}
[ foregroundGuess, labelGuess ] = kmeansGuess( smallImage, nColors );
repmat( labelGuess, [1,1,3]);

%�ϥ�segRefine
labelRefined = segRefine(thisImg, labelGuess);
labelRefined = imfill(labelRefined, 'holes');%��}�}
labelRefined3 = repmat(labelRefined, [1,1,3]);
thisImg = double(thisImg)/255;

foregroundRefined = thisImg .* labelRefined3;



end