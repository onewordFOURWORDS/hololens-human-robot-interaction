using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

#if ENABLE_WINMD_SUPPORT
using Windows.Storage;
using Windows.Storage.Streams;
#endif

public static class FileWriter
{   
    #if ENABLE_WINMD_SUPPORT
    private static StorageFolder _directoryName;
    private static StorageFile _logFile;
    #endif

    public static async void createDirectory()
    {
        #if ENABLE_WINMD_SUPPORT
            _directoryName = await DownloadsFolder.CreateFolderAsync("Hololens_Robot_Interaction", 
                                                Windows.Storage.CreationCollisionOption.FailIfExists);
        #endif
    }

    public static async void createFile()
    {
        #if ENABLE_WINDMD_SUPPORT
             _logFile = await _directoryName.CreateFileAsync("Test.txt",
                                            Windows.Storage.CreationCollisionOption.FailIfExists);
        #endif
    }

    public static async void logData(string data)
    {
        #if ENABLE_WINMD_SUPPORT
            await Windows.Storage.FileIO.WriteTextAsync(_logFile, data);
        #endif
    }
    
}