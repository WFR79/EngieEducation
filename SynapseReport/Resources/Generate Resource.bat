"C:\PROGRAM FILES (X86)\MICROSOFT SDKS\WINDOWS\V7.0A\BIN\RESGEN.EXE" "C:\My Projects\CSharp 2010\Synapse\Main\src\SynapseReport\Resources\formLabels.fr-BE.txt"
"C:\PROGRAM FILES (X86)\MICROSOFT SDKS\WINDOWS\V7.0A\BIN\RESGEN.EXE" "C:\My Projects\CSharp 2010\Synapse\Main\src\SynapseReport\Resources\formLabels.nl-BE.txt"
"C:\PROGRAM FILES (X86)\MICROSOFT SDKS\WINDOWS\V7.0A\BIN\RESGEN.EXE" "C:\My Projects\CSharp 2010\Synapse\Main\src\SynapseReport\Resources\formLabels.en-US.txt"
"C:\PROGRAM FILES (X86)\MICROSOFT SDKS\WINDOWS\V7.0A\BIN\RESGEN.EXE" "C:\My Projects\CSharp 2010\Synapse\Main\src\SynapseReport\Resources\formLabels.txt"
DEL "C:\My Projects\CSharp 2010\Synapse\Main\src\SynapseReport\bin\Debug\Resources\*.resources"
XCOPY *.resources "C:\My Projects\CSharp 2010\Synapse\Main\src\SynapseReport\bin\Debug\Resources\"
DEL "C:\My Projects\CSharp 2010\Synapse\Main\src\SynapseReport\bin\Debug\Resources\*.txt"
XCOPY *.txt "C:\My Projects\CSharp 2010\Synapse\Main\src\SynapseReport\bin\Debug\Resources\"
pause