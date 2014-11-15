function [ fgLabel, bgLabel ] = getPredefinedLabel_Meow( image )

[h, w, ~] = size(image);
w_unit = floor(w/16);
h_unit = floor(h/24);

%����Label�A���]����1/16~15/16���~�ܥi�ର�I���A�]��2/24~22/24���~�ܥi�ର�I��
fgLabel =  zeros(h, w);
fgLabel( h_unit*2:h_unit*22 , w_unit*2:w_unit*14 ) =1;

%����Label�A���]����3/16~12/13�����ܥi��O�e���A�]��4/24~20/24�����ܥi�ର�e��
bgLabel = ones(h, w);
bgLabel( h_unit*4:h_unit*20 , w_unit*3:w_unit*13 ) =1;
end

