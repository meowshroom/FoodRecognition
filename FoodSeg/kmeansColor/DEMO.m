clear all; close all; clc

addpath ( 'gcoSeg', 'utilities' ) ;

%Input Directory
[fileNames, filePaths] = getAllFiles('foods_Input');

%Output Directory
outputDir1 = 'result(Montage)';
if exist(outputDir1) ~=7
		mkdir(outputDir1);
end

outputDir2 = 'result(ForeGround)';
if exist(outputDir2) ~=7
		mkdir(outputDir2);
end

%Do kmeans segmentation
lastContent = ''; %Prompt
for imgI = 1 : length(filePaths)
	lastContent = printPrompt( lastContent, sprintf( 'Processing Image... %d / %d', imgI, length(filePaths) ) );
	
	% Read image and resize
	thisImg = imread( filePaths{imgI} );
	thisImg = rotateAndResizeImage_Meow( thisImg );
	
	%�ϥΡukmeans�q��_�ߡv
	%labelGuess : �ϥΡukmeans�q��_�ߡv�q���ұo��Label
	%foregroundGuess : �ϥΡulabelGuess�v�n�b�uthisImg�v�W�ұo���v���A�I�������O�¦⪺
	[ foregroundGuess, labelGuess ] = kmeansGuess_Meow( thisImg, 3, 0.40, 0.6 );
	repmat( labelGuess, [1,1,3]);
	
	%�ϥ�segRefine
	%labelRefined : ��}�L�᪺label
	%foregroundRefined : �ϥΡulabelRefined�v�n�bthisImg�W�ұo���v���A�I�������O�¦⪺
	labelRefined = segRefine(thisImg, labelGuess);
	labelRefined = imfill(labelRefined, 'holes');%��}�}�A���
	labelRefined3 = repmat(labelRefined, [1,1,3]);
	thisImg = double(thisImg)/255;
	
	foregroundRefined = thisImg .* labelRefined3;
	
	%��X�Ϥ�
	thisImg_montage = [ thisImg, foregroundGuess, foregroundRefined ];
	imwrite( thisImg_montage, strcat( outputDir1, '/', fileNames{imgI}, '.png') );
	imwrite( foregroundRefined, strcat( outputDir2, '/', fileNames{imgI}, '.png') );
	
end