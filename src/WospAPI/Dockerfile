FROM microsoft/dotnet:latest
COPY ./bin/Release/netcoreapp1.0/publish /root/
COPY ./wosp.pfx /root/wosp.pfx
EXPOSE 80/tcp 443/tcp
ENTRYPOINT dotnet /root/WospAPI.dll