clear all; close all; clc

% Load the "Word to Color Mames matrix". The words are a 32x32x32 grid on the sRGB space.
load('w2c.mat');


%% Example 1
img_cat=double(imread('cat.png'));
mask_cat=rgb2gray( double(imread('catmask.png'))/255 );

tic
%大量時，請用mode 0，請參見 getColorNameVector_Meow
[ colorNameVector1, compressedImage1 ] = getColorNameVector_Meow( img_cat, 1, mask_cat, w2c ); 
toc

drawColorNameVectorPie_Meow( colorNameVector1, compressedImage1, mask_cat );

%% Example 2
img_apple=double(imread('apple.jpg'));
mask_apple=rgb2gray( double(imread('applemask.png'))/255 );

tic
[ colorNameVector2, compressedImage2 ] = getColorNameVector_Meow( img_apple, 1, mask_apple, w2c );
toc

drawColorNameVectorPie_Meow( colorNameVector2, compressedImage2, mask_apple );