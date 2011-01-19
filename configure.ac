AC_PREREQ([2.54])
AC_INIT([zeitgeist-sharp], [0.1.1.0])
AM_INIT_AUTOMAKE([foreign])
AM_MAINTAINER_MODE

dnl pkg-config
AC_PATH_PROG(PKG_CONFIG, pkg-config, no)
if test "x$PKG_CONFIG" = "xno"; then
        AC_MSG_ERROR([You need to install pkg-config])
fi

SHAMROCK_EXPAND_LIBDIR
SHAMROCK_EXPAND_BINDIR
SHAMROCK_EXPAND_DATADIR

AC_PROG_INSTALL

# DO NOT TOUCH!
# Except you know what you do
# This defines the library ABI version!
ASSEMBLY_VERSION="0.1.0.1"
AC_SUBST(ASSEMBLY_VERSION)

PKG_CHECK_MODULES([MONO], [mono >= 2.4])

AC_PATH_PROG(GMCS, gmcs, no)
if test "x$GMCS" = "xno"; then
        AC_MSG_ERROR([You need to install gmcs])
fi

AC_PATH_PROG(XBUILD, xbuild, no)
if test "x$XBUILD" = "xno"; then
        AC_MSG_ERROR([You need to install xbuild])
fi

AC_PATH_PROG(GACUTIL, gacutil)
if test x$GACUTIL = x; then
	AC_MSG_ERROR([You need to install gacutil])
fi
GACUTIL_FLAGS='-root $(DESTDIR)$(libdir)'
AC_SUBST(GACUTIL_FLAGS)

dnl package checks, common for all configs
PKG_CHECK_MODULES([NDESK_DBUS_10], [ndesk-dbus-1.0])
PKG_CHECK_MODULES([NDESK_DBUS_GLIB_10], [ndesk-dbus-glib-1.0])
PKG_CHECK_MODULES([GLIB_SHARP_20], [glib-sharp-2.0])

AC_CONFIG_FILES([
Zeitgeist/zeitgeist-sharp.pc
Zeitgeist/AssemblyInfo.cs
Zeitgeist/Makefile
Makefile
])

AC_OUTPUT
