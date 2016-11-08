FROM microsoft/dotnet:latest
COPY ./bin/Release/netcoreapp1.0/publish /root/
COPY /usr/share/ssl-self/wosp.crt /root/wosp.crt
COPY /usr/share/ssl-self/wosp.key /root/wosp.key
EXPOSE 80/tcp
EXPOSE 443/tcp
ENTRYPOINT dotnet /root/WospAPI.dll