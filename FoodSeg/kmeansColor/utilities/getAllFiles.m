function [fileNames, filePaths] = getAllFiles(dirName)

dirData = dir(dirName);      %Get the data for the current directory
dirIndex = [dirData.isdir];  %Find the index for directories
fileNames = {dirData(~dirIndex).name}';  %'# Get a list of the files
if ~isempty(fileNames)
	%Prepend path to files
	filePaths = cellfun(@(x) fullfile(dirName,x), fileNames,'UniformOutput',false);
end

subDirs = {dirData(dirIndex).name};  %Get a list of the subdirectories
validIndex = ~ismember(subDirs,{'.','..'});  %Find index of subdirectories
%  that are not '.' or '..'

for iDir = find(validIndex)                  %Loop over valid subdirectories
	nextDir = fullfile(dirName,subDirs{iDir});    %Get the subdirectory path
	filePaths = [fileList; getAllFiles(nextDir)];  %Recursively call getAllFiles
end

end