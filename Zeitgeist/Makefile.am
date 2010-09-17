
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/Zeitgeist.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

ZEITGEIST_DLL_MDB_SOURCE=bin/Debug/Zeitgeist.dll.mdb
ZEITGEIST_DLL_MDB=$(BUILD_DIR)/Zeitgeist.dll.mdb

endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/Zeitgeist.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

ZEITGEIST_DLL_MDB=

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(ZEITGEIST_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(ZEITGEIST_PC)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES = \
	AssemblyInfo.cs \
	Datamodel/Event.cs \
	Datamodel/Subject.cs \
	Datamodel/ResultType.cs \
	Datamodel/TimeRange.cs \
	Datamodel/StorageState.cs \
	Datamodel/DataSource.cs \
	Delegates.cs \
	Client/IDataSource.cs \
	Client/IBlacklist.cs \
	Client/ILog.cs \
	DataSourceClient.cs \
	BlacklistClient.cs \
	LogClient.cs \
	ZsUtils.cs \
	Datamodel/Interpretation.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	Datamodel \
	Client \
	zeitgeist.pc.in 

REFERENCES =  \
	System \
	$(NDESK_DBUS_10_LIBS) \
	$(NDESK_DBUS_GLIB_10_LIBS)

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

ZEITGEIST_PC = $(BUILD_DIR)/zeitgeist.pc

$(eval $(call emit-deploy-wrapper,ZEITGEIST_PC,zeitgeist.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
