function [ fgLabel, bgLabel ] = getPredefinedLabel_Meow( image )

[h, w, ~] = size(image);
w_unit = floor(w/16);
h_unit = floor(h/24);

%產生Label，假設水平1/16~15/16之外很可能為背景，鉛直2/24~22/24之外很可能為背景
fgLabel =  zeros(h, w);
fgLabel( h_unit*2:h_unit*22 , w_unit*2:w_unit*14 ) =1;

%產生Label，假設水平3/16~12/13之內很可能是前景，鉛直4/24~20/24之內很可能為前景
bgLabel = ones(h, w);
bgLabel( h_unit*4:h_unit*20 , w_unit*3:w_unit*13 ) =1;
end

