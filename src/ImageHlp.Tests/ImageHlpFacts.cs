﻿// Copyright © .NET Foundation and Contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using PInvoke;
using Xunit;
using static PInvoke.DbgHelp;
using static PInvoke.ImageHlp;

public class ImageHlpFacts
{
    [Fact]
    [Trait("skiponcloud", "true")]
    [Trait("TestCategory", "FailsInCloudTest")]
    public void MapAndLoadTest()
    {
        LOADED_IMAGE imageData;
        Assert.True(MapAndLoad("kernel32.dll", null, out imageData, true, true));
        try
        {
            Assert.True(imageData.fReadOnly);
            Assert.Contains("kernel32", imageData.ModuleName, StringComparison.OrdinalIgnoreCase);
        }
        finally
        {
            Assert.True(UnMapAndLoad(ref imageData));
        }
    }
}
