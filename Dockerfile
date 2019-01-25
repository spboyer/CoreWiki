<<<<<<< HEAD
FROM cakebuild/cake:v0.30.0-2.1-sdk AS builder
=======
FROM cakebuild/cake:v0.28.1-2.1-sdk AS builder
>>>>>>> upstream/master

RUN apt-get update -qq \
    && curl -sL https://deb.nodesource.com/setup_9.x | bash - \
    && apt-get install -y nodejs

ADD .  /src

RUN Cake /src/build.cake --Target=Publish

<<<<<<< HEAD
FROM microsoft/dotnet:2.1.3-aspnetcore-runtime
=======
FROM microsoft/dotnet:2.1.1-aspnetcore-runtime
>>>>>>> upstream/master

WORKDIR app

COPY --from=builder /src/output .

CMD ["dotnet","CoreWiki.dll"]

