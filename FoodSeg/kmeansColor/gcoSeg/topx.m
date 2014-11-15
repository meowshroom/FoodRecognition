function A=topx(M,h)
    
    i=mod(M,h);
    ind=find(i==0);
    i(ind)=h;
    %i;
    A=[i';ceil(M/h)'];
    A=A';
    
    
end