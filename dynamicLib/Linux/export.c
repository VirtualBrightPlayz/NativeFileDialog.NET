#ifdef __cplusplus
extern "C" {
#endif

#include <stddef.h>
#include <nfd.h>

#ifdef _WIN32
#define EXPORT(x) __declspec(dllexport) x  __cdecl
#elif defined __APPLE__
#define EXPORT(x) x __attribute__((visibility("default")))
#else
#define EXPORT(x) x
#endif

/* single file open dialog */
EXPORT(nfdresult_t) NFD_DLL_OpenDialog(const nfdchar_t* filterList,
    const nfdchar_t* defaultPath,
    nfdchar_t** outPath) {
    return NFD_OpenDialog(filterList, defaultPath, outPath);
}

/* multiple file open dialog */
EXPORT(nfdresult_t) NFD_DLL_OpenDialogMultiple(const nfdchar_t* filterList,
    const nfdchar_t* defaultPath,
    nfdpathset_t* outPaths) {
    return NFD_OpenDialogMultiple(filterList, defaultPath, outPaths);
}


/* save dialog */
EXPORT(nfdresult_t) NFD_DLL_SaveDialog(const nfdchar_t* filterList,
    const nfdchar_t* defaultPath,
    nfdchar_t** outPath) {
    return NFD_SaveDialog(filterList, defaultPath, outPath);
}


/* select folder dialog */
EXPORT(nfdresult_t) NFD_DLL_PickFolder(const nfdchar_t* defaultPath, nfdchar_t** outPath) {
    return NFD_PickFolder(defaultPath, outPath);
}

/* NFD_DLL_common.c */

/* get last error -- set when nfdresult_t returns NFD_DLL_ERROR */
EXPORT(const char*) NFD_DLL_GetError(void) {
    return NFD_GetError();
}
/* get the number of entries stored in pathSet */
EXPORT(size_t) NFD_DLL_PathSet_GetCount(const nfdpathset_t* pathSet) {
    return NFD_PathSet_GetCount(pathSet);
}
/* Get the UTF-8 path at offset index */
EXPORT(nfdchar_t*) NFD_DLL_PathSet_GetPath(const nfdpathset_t* pathSet, size_t index) {
    return NFD_PathSet_GetPath(pathSet, index);
}
/* Free the pathSet */
EXPORT(void) NFD_DLL_PathSet_Free(nfdpathset_t* pathSet) {
    return NFD_PathSet_Free(pathSet);
}
/* Free any other memory allocated by NFD */
EXPORT(void) NFD_DLL_Free(void* ptr) {
    return NFD_Free(ptr);
}

#ifdef __cplusplus
}
#endif
