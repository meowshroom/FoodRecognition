function distance = B_distance(f, g)

%{
if sum(sum(sum(f))) ~= 0
    f = f./(sum(sum(sum(f))));
end

if sum(sum(sum(g))) ~= 0
    g = g./(sum(sum(sum(g))));
end
%}

distance = sum(sum(sum((f.*g).^0.5)));

end