#!/usr/bin/env bash
# Define varibles
<<<<<<< HEAD
CAKE_VERSION=0.30.0
DOTNET_VERSION=2.1.403
SCRIPT_DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )
TOOLS_DIR=$SCRIPT_DIR/tools
CAKE_EXE=$TOOLS_DIR/dotnet-cake
CAKE_PATH=$TOOLS_DIR/.store/cake.tool/$CAKE_VERSION
=======
CAKE_VERSION=0.28.1
DOTNET_SDK_VERSION=2.1.4
SCRIPT_DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )
TOOLS_DIR=$SCRIPT_DIR/tools
CAKE_DLL=$TOOLS_DIR/Cake.CoreCLR.$CAKE_VERSION/Cake.dll
>>>>>>> upstream/master

# Make sure the tools folder exist.
if [ ! -d "$TOOLS_DIR" ]; then
  mkdir "$TOOLS_DIR"
fi

###########################################################################
<<<<<<< HEAD
# INSTALL .NET CORE CLI
###########################################################################

echo "Installing .NET CLI..."
if [ ! -d "$SCRIPT_DIR/.dotnet" ]; then
  mkdir "$SCRIPT_DIR/.dotnet"
fi
curl -Lsfo "$SCRIPT_DIR/.dotnet/dotnet-install.sh" https://dot.net/v1/dotnet-install.sh
bash "$SCRIPT_DIR/.dotnet/dotnet-install.sh" --version $DOTNET_VERSION --install-dir .dotnet --no-path
export PATH="$SCRIPT_DIR/.dotnet":$PATH
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export DOTNET_CLI_TELEMETRY_OPTOUT=1
export DOTNET_SYSTEM_NET_HTTP_USESOCKETSHTTPHANDLER=0


###########################################################################
# INSTALL CAKE
###########################################################################

if [ ! -f "$CAKE_EXE" ] || [ ! -d "$CAKE_PATH" ]; then
    echo "Installing Cake $CAKE_VERSION..."
    dotnet tool install --tool-path $TOOLS_DIR --version $CAKE_VERSION Cake.Tool
=======
# INSTALL CAKE
###########################################################################

if [ ! -f "$CAKE_DLL" ]; then
    echo "Installing Cake $CAKE_VERSION..."
    curl -Lsfo Cake.zip "https://www.nuget.org/api/v2/package/Cake.CoreCLR/$CAKE_VERSION" && unzip -q Cake.zip -d "$TOOLS_DIR/Cake.CoreCLR.$CAKE_VERSION" && rm -f Cake.zip
>>>>>>> upstream/master
    if [ $? -ne 0 ]; then
        echo "An error occured while installing Cake."
        exit 1
    fi
fi

# Make sure that Cake has been installed.
<<<<<<< HEAD
if [ ! -f "$CAKE_EXE" ]; then
    echo "Could not find Cake.exe at '$CAKE_EXE'."
=======
if [ ! -f "$CAKE_DLL" ]; then
    echo "Could not find Cake.exe at '$CAKE_DLL'."
>>>>>>> upstream/master
    exit 1
fi

###########################################################################
# RUN BUILD SCRIPT
###########################################################################

# Start Cake
<<<<<<< HEAD
(exec "$CAKE_EXE" build.cake --bootstrap) && (exec "$CAKE_EXE" build.cake "$@")
=======
(exec dotnet "$CAKE_DLL" build.cake --bootstrap) && (exec dotnet "$CAKE_DLL" build.cake "$@")
>>>>>>> upstream/master
