function histogram = computeDistribution(img)

imgH = size(img, 1);
imgW = size(img, 2);

histogram = zeros(128,128,128);

for i = 1:imgH
    for j = 1:imgW
        r = ceil((double(img(i,j,1))+1)/2);  %%%無條件進位
        g = ceil((double(img(i,j,2))+1)/2);
        b = ceil((double(img(i,j,3))+1)/2);
        histogram(r,g,b) = histogram(r,g,b) + 1;
    end
end

%{
% normalize
sumHistogram= sum(sum(sum(histogram)));

if(sumHistogram~=0)
    histogram = histogram ./ sumHistogram;
end
%}
end