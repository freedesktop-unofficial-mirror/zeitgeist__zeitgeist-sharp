
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/Zeitgeist.ZeitgeistSharp.Cli.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../Zeitgeist/bin/Debug/Zeitgeist.dll
BUILD_DIR = bin/Debug

ZEITGEIST_DLL_SOURCE=../Zeitgeist/bin/Debug/Zeitgeist.dll
ZEITGEIST_DLL_MDB_SOURCE=../Zeitgeist/bin/Debug/Zeitgeist.dll.mdb
ZEITGEIST_ZEITGEISTSHARP_CLI_EXE_MDB_SOURCE=bin/Debug/Zeitgeist.ZeitgeistSharp.Cli.exe.mdb
ZEITGEIST_ZEITGEISTSHARP_CLI_EXE_MDB=$(BUILD_DIR)/Zeitgeist.ZeitgeistSharp.Cli.exe.mdb

endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/Zeitgeist.ZeitgeistSharp.Cli.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../Zeitgeist/bin/Release/Zeitgeist.dll
BUILD_DIR = bin/Release

ZEITGEIST_DLL_SOURCE=../Zeitgeist/bin/Debug/Zeitgeist.dll
ZEITGEIST_DLL_MDB_SOURCE=../Zeitgeist/bin/Debug/Zeitgeist.dll.mdb
ZEITGEIST_ZEITGEISTSHARP_CLI_EXE_MDB=

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(ZEITGEIST_DLL) \
	$(ZEITGEIST_DLL_MDB) \
	$(ZEITGEIST_ZEITGEISTSHARP_CLI_EXE_MDB)  

BINARIES = \
	$(ZEITGEIST_CLI)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES) 

FILES = \
	Main.cs \
	AssemblyInfo.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	zeitgeist.cli.in 

REFERENCES =  \
	System \
	$(NDESK_DBUS_10_LIBS) \
	$(NDESK_DBUS_GLIB_10_LIBS)

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

include $(top_srcdir)/Makefile.include

ZEITGEIST_DLL = $(BUILD_DIR)/Zeitgeist.dll
ZEITGEIST_DLL_MDB = $(BUILD_DIR)/Zeitgeist.dll.mdb
ZEITGEIST_CLI = $(BUILD_DIR)/zeitgeist.cli

$(eval $(call emit-deploy-target,ZEITGEIST_DLL))
$(eval $(call emit-deploy-target,ZEITGEIST_DLL_MDB))
$(eval $(call emit-deploy-wrapper,ZEITGEIST_CLI,zeitgeist.cli,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
