CC := gcc
CFLAGS := -O2 -fPIC
nfd.so: export.o
	@echo "Building nfd.so"
	@$(CC) export.o -shared -o nfd.so

export.o: nfd.a
	@echo "Building export.o"
	@$(CC) -I ../../nativefiledialog/src/include/ -c $(CFLAGS) export.c -o export.o

nfd.a:
	@echo "Building nfd.a"
	@make ../../nativefiledialog/build/gmake_linux/
