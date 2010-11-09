OUTPUT_DIR = $(top_builddir)/bin
OBJECT_DIR = $(OUTPUT_DIR)/obj
SOURCE_PATTERNS = *.cs */*.cs */*/*.cs */*/*/*.cs
XBUILD_FLAGS = /p:Configuration=Debug /p:WarningLevel=0 /p:OutputPath=$(abspath $(OUTPUT_DIR)) /p:BaseIntermediateOutputPath=$(abspath $(OBJECT_DIR))/ /p:DocumentationFile=

ZS_SOURCE_FILES = $(foreach pattern, $(SOURCE_PATTERNS), $(wildcard $(pattern)))
ZS_ASSEMBLY_NAME = zeitgeist-sharp
ZS_ASSEMBLY_TARGET = $(OUTPUT_DIR)/$(ZS_ASSEMBLY_NAME).dll
ZS_ASSEMBLY_PC = $(srcdir)/$(PACKAGE_NAME).pc
ZS_BUILD_FILE = $(srcdir)/Zeitgeist.csproj
ZS_XBUILD_FLAGS = $(XBUILD_FLAGS)
ZS_GACUTIL_INSTALL = $(GACUTIL) -i $(ZS_ASSEMBLY_TARGET) -f $(GACUTIL_FLAGS)
ZS_GACUTIL_UNINSTALL = $(GACUTIL) -u $(ZS_ASSEMBLY_NAME) $(GACUTIL_FLAGS)

# magic automake variables
pkglib_DATA = \
	$(ZS_ASSEMBLY_TARGET) $(ZS_ASSEMBLY_TARGET).mdb

EXTRA_DIST = \
	 $(ZS_SOURCE_FILES) $(ZS_BUILD_FILE) zeitgeist-sharp.snk

pkgconfigdir = $(libdir)/pkgconfig
pkgconfig_DATA = $(ZS_ASSEMBLY_PC)
# end of magic

$(ZS_ASSEMBLY_TARGET) $(ZS_ASSEMBLY_TARGET).mdb: $(ZS_BUILD_FILE) $(ZS_SOURCE_FILES)
	$(XBUILD) $(ZS_XBUILD_FLAGS) $(ZS_BUILD_FILE)

clean-local:
	$(XBUILD) $(ZS_XBUILD_FLAGS) /t:Clean $(ZS_BUILD_FILE)

install-data-local: $(ZS_ASSEMBLY_TARGET) $(ZS_ASSEMBLY_TARGET).mdb
	echo "$(ZS_GACUTIL_INSTALL)";  \
	  $(ZS_GACUTIL_INSTALL)  || exit 1;

uninstall-local: 
	echo "$(ZS_GACUTIL_UNINSTALL)";  \
	  $(ZS_GACUTIL_UNINSTALL)  || exit 1;
