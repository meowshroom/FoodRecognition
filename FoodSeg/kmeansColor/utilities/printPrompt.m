function [ lastContent ] = printPrompt( lastContent, content )

fprintf( repmat('\b',[1, length(lastContent)]) );
lastContent = content;

fprintf( content );
end

