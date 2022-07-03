CC := gcc
CFLAGS := -O2 -fPIC
nfd.so: export.o
	@echo "Building nfd.so"
	@$(CC) export.o -L. -l:../../nativefiledialog/build/lib/Release/x64/libnfd.a -lgtk-3 -shared -o nfd.so

export.o: nfd.a
	@echo "Building export.o"
	@$(CC) -I ../../nativefiledialog/src/include/ -c $(CFLAGS) export.c -o export.o

nfd.a:
	@echo "Building nfd.a"
	@make -C ../../nativefiledialog/build/gmake_linux/ clean
	@make CFLAGS=-fPIC -C ../../nativefiledialog/build/gmake_linux/
