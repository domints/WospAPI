FROM microsoft/dotnet:latest
COPY ./bin/Release/netcoreapp1.0/publish /root/
COPY ./wosp.crt /root/wosp.crt
COPY ./wosp.key /root/wosp.key
EXPOSE 80/tcp 443/tcp
ENTRYPOINT dotnet /root/WospAPI.dll