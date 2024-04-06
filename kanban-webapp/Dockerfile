FROM mcr.microsoft.com/dotnet/sdk:8.0

ENV ASPNETCORE_URLS=http://+:5000

WORKDIR /var/www/aspnetcoreapp

COPY . .

EXPOSE 5000
CMD dotnet restore; dotnet ef database update; dotnet run