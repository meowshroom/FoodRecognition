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
	
	%使用「kmeans猜測_貓」
	%labelGuess : 使用「kmeans猜測_貓」猜測所得的Label
	%foregroundGuess : 使用「labelGuess」罩在「thisImg」上所得的影像，背景部分是黑色的
	[ foregroundGuess, labelGuess ] = kmeansGuess_Meow( thisImg, 3, 0.40, 0.6 );
	repmat( labelGuess, [1,1,3]);
	
	%使用segRefine
	%labelRefined : 改良過後的label
	%foregroundRefined : 使用「labelRefined」罩在thisImg上所得的影像，背景部分是黑色的
	labelRefined = segRefine(thisImg, labelGuess);
	labelRefined = imfill(labelRefined, 'holes');%填洞洞，選用
	labelRefined3 = repmat(labelRefined, [1,1,3]);
	thisImg = double(thisImg)/255;
	
	foregroundRefined = thisImg .* labelRefined3;
	
	%輸出圖片
	thisImg_montage = [ thisImg, foregroundGuess, foregroundRefined ];
	imwrite( thisImg_montage, strcat( outputDir1, '/', fileNames{imgI}, '.png') );
	imwrite( foregroundRefined, strcat( outputDir2, '/', fileNames{imgI}, '.png') );
	
end