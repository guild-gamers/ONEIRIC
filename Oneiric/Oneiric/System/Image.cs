﻿using System;
using Tao.Sdl;
[Serializable]
class Image
{
    private IntPtr internalPointer;

    public Image(string fileName)  // Constructor
    {
        Load(fileName);
    }

    public void Load(string fileName)
    {
        internalPointer = SdlImage.IMG_Load(fileName);
        if (internalPointer == IntPtr.Zero)
        {
            Oneiric.SaveLog("Image not found: " + fileName);
            SdlHardware.FatalError("Image not found: " + fileName);
        }
    }


    public IntPtr GetPointer()
    {
        return internalPointer;
    }
}