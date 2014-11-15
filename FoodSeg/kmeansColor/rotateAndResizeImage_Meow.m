function [ image ] = rotateAndResizeImage_Meow( image )
%Turned into horizontal if it is originally vertical
%If image is bigger than 400 กั 300, then it will be resized

[h, w, ~] = size(image);

%Rotate image if it is originally vertical
if h>w
	image=imrotate(image, 90, 'bicubic');
	[h, w, ~] = size(image);
end

%Resize image if it is too big
if h>300
	image=imresize(image, 300/h, 'bicubic');
	[~, w, ~] = size(image);
end
if w>400
	image=imresize(image, 400/w, 'bicubic');
end

end

