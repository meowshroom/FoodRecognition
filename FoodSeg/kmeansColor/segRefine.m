function outputLabel = segRefine(inputImg, label)

inputImg = double(inputImg);
imgH = size(inputImg, 1);
imgW = size(inputImg, 2);
rMatrix = inputImg(:,:,1);
gMatrix = inputImg(:,:,2);
bMatrix = inputImg(:,:,3);

%X = [800/2-300 800/2+300];      %%% X邊界
%Y = [600/2-299 600/2+299];      %%% Y邊界
%boxImg = inputImg(Y(1):Y(2), X(1):X(2), 1:3);

X = [1, size(inputImg,2)];      %%% X邊界
Y = [1, size(inputImg,1)];      %%% Y邊界
boxImg = inputImg;


boxH = size(boxImg, 1);
boxW = size(boxImg, 2);


%figure;imshow(uint8(boxImg));
% 先算 M 和 H, 128*128*128 histogram

index = find(label == 0);
threeColorMatrix(:,:,1) = rMatrix(index);
threeColorMatrix(:,:,2) = gMatrix(index);
threeColorMatrix(:,:,3) = bMatrix(index);
M = computeDistribution(threeColorMatrix);    %%% M為三維的histogram
M = M./sum(sum(sum(M)));      %%% 除以總數(換成機率)
H = M;
clear index threeColorMatrix;

%{
histogram1 = computeDistribution(inputImg);
histogram2 = computeDistribution(boxImg);
M = histogram1 - histogram2;
M = M./sum(sum(sum(M)));
H = M;
%}
%%
dataCost = zeros(2, boxH*boxW);
e = 0.001;
lamda = 0.002;
%alpha = 0.85;
alpha = 0.85;
noise1 = 1000000;
noise2 = -100000000000;

%L_star = label+1;
L_star = ones(imgH,imgW);

% L_star定義的背景分布 P_L_star_0
index = find(L_star == 1);
threeColorMatrix(:,:,1) =  rMatrix(index);
threeColorMatrix(:,:,2) =  gMatrix(index);
threeColorMatrix(:,:,3) =  bMatrix(index);
P_L_star_0 = computeDistribution(threeColorMatrix); 
if(sum(sum(sum(P_L_star_0)))~=0)
    P_L_star_0 = P_L_star_0./sum(sum(sum(P_L_star_0)));
end
clear index threeColorMatrix;

% L_star定義的前景分布 P_L_star_1
index = find(L_star == 2);     %%% ???
threeColorMatrix(:,:,1) =  rMatrix(index);
threeColorMatrix(:,:,2) =  gMatrix(index);
threeColorMatrix(:,:,3) =  bMatrix(index);
P_L_star_1 = computeDistribution(threeColorMatrix);
if(sum(sum(sum(P_L_star_1)))~=0)
    P_L_star_1 = P_L_star_1./sum(sum(sum(P_L_star_1)));
end
clear index threeColorMatrix;

F1_L_star = B_distance(P_L_star_1, H); % 前    %%%???
F2_L_star = -B_distance(P_L_star_0, H); % 背
F_L_star = F1_L_star + F2_L_star;

A_R_L_star_0 = size(find(L_star == 1),1); % L_star 決定的背景個數
A_R_L_star_1 = size(find(L_star == 2),1); % L_star 決定的前景個數
if(A_R_L_star_1==0)        %%% ???
   A_R_L_star_1 = 1;
   P_L_star_1(:,:,:)=1;
end

%%
%　計算 data term  %
tempDataCost = zeros(boxH, boxW, 2);
tmp = zeros(boxH, boxW);
for i = 1:boxH
    for j = 1:boxW
        
        % 算 node 和 labe = 1 的 cost  (背景)   
        temp = (sign(F_L_star)*alpha + 1) * (F_L_star/A_R_L_star_0);
        %tempDataCost(i,j,1) = temp*(1-votW) + vImg(i,j)*votW;
        tempDataCost(i,j,1) = temp;
        
        % 算 node 和 labe = 2 的 cost  (前景)
        if( L_star(i+Y(1)-1, j+X(1)-1) == 1)
            r = ceil((double(boxImg(i,j,1))+1)/2);
            g = ceil((double(boxImg(i,j,2))+1)/2);
            b = ceil((double(boxImg(i,j,3))+1)/2);
            
            if(P_L_star_1(r,g,b)==0 && A_R_L_star_1~=0)
                P_L_star_1(r,g,b)=0.001;
            end
            if(P_L_star_0(r,g,b)==0 )
                P_L_star_0(r,g,b)=0.001;
            end
            %%% ↑↑↑預防分母為零
            
            temp = ((H(r,g,b)/P_L_star_1(r,g,b))^0.5) / (2*A_R_L_star_1) + (((H(r,g,b)/P_L_star_0(r,g,b))^0.5)+F_L_star) / A_R_L_star_0;
            tempDataCost(i,j,2) = temp;
%             tmp(i,j) = temp*(1-votW) + box_vImg(i, j)*votW;

%             tempDataCost(i,j,2) = tmp(i,j);
        end
        
    end
end
tt=reshape(tempDataCost,boxH*boxW,2);
tt=(tt-min(min(tt)))/(max(max(tt))-min(min(tt)));
dataCost(1,:) = tt(:,1)'.*noise1;
dataCost(2,:) = tt(:,2)'.*noise1;

%　計算 smoothness term  %
imgd=double(reshape(boxImg,boxH*boxW,3));
N = boxH*boxW;

%E = edges4connected(h,w);
[ic icd]=ixneighbors(zeros(boxH,boxW));
E=[ic icd];                              %%% ic?? icd???
pd=imgd(E(:,1),:)-imgd(E(:,2),:);
p=topx(E(:,1),boxH);
q=topx(E(:,2),boxH);
%V=round(noise2*lamda*(1./(1+sum(abs(pendd').^2,1))+ (e./sqrt(sum(abs((p-q)').^2,1)))));
V=noise2*(1./(1+sum(abs(pd').^2,1))+ (e./sqrt(sum(abs((p-q)').^2,1))));
%V=V/norm(V);
V=(V-min(V))/(max(V)-min(V));

L_star2=L_star(Y(1):Y(2),X(1):X(2));     %%% ??? L_star沒有asign 0 or 2的時候
gcount=size(find(L_star2==1));
fgcount=size(find(L_star2==2));      
for k=1:size(E,1)
    if(L_star2(E(k,1))==L_star2(E(k,2)))
        V(k)=0; 
    end
end

A = sparse(E(:,1),E(:,2),V,N,N);     %%% A??

%　Grapg Cuts 算 label %
h = GCO_Create(boxW*boxH,2);

%%%~~~
dataCost = int32(dataCost);
GCO_SetDataCost(h,dataCost);
GCO_SetNeighbors(h,A);
GCO_Expansion(h);
L2 = GCO_GetLabeling(h);     %%% 切完的L(一維)
[E D S] = GCO_ComputeEnergy(h);
GCO_Delete(h);

L2(L2==1)=0;
L2(L2==2)=1;

% L3=reshape(L2,boxH,boxW);    %%% 轉二維
% out(:,:,1) = double(boxImg(:,:,1)).*double(L3);
% out(:,:,2) = double(boxImg(:,:,2)).*double(L3);
% out(:,:,3) = double(boxImg(:,:,3)).*double(L3);

%figure;imshow(uint8(out));


L4=L2;%0:背景 1:前景
L4(L4==1)=255;%1->255
I2=reshape(double(L4),boxH,boxW);
se=strel('square',1);
erodebw=imerode(I2,se);
L5=double(erodebw);
L5(find(erodebw>0))=1;
L_star(Y(1):Y(2), X(1):X(2)) = L5+1;
%imwrite(L5*255,'eroded.jpg');
%%
L6=L5;
se=strel('square',3);
afterClosing=imclose(L6,se);
% 連通成份抽取(標記) labeling 
afterLabeling = bwlabel(afterClosing,4); %4代表4鄰接?通，亦可用8(8鄰接?通)
rgbLabels = label2rgb(afterLabeling, @jet, 'k'); %以色彩標記?同區塊，背景為黑色’k’

%將各區塊分別編號。
stats=regionprops(afterLabeling,'basic'); %找出相同的並統計
allArea=[stats.Area];tt=max(allArea); % 找出最大的區塊pixel,此例為34
idx=find(allArea==tt);
biggest_block=ismember(afterLabeling,idx);% afterLabeling中有哪些元素在idx中
%{
out(:,:,1) = double(boxImg(:,:,1)).*double(biggest_block);
out(:,:,2) = double(boxImg(:,:,2)).*double(biggest_block);
out(:,:,3) = double(boxImg(:,:,3)).*double(biggest_block);
figure;imshow(uint8(out));
%}

outputLabel=zeros(imgH,imgW);
outputLabel(Y(1):Y(2),X(1):X(2))=double(biggest_block);

% se=strel('square',5);
% outputLabel = imclose(outputLabel, se);
%figure;imshow(outputLabel);


end