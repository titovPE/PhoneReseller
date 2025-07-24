using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System;
using System.Runtime.InteropServices;

namespace LicenseGenerator
{
    class KeySelector
    {
        const string DRIVE_NAME = @"\\.\PHYSICALDRIVE0";
        public void AddHddPropertyToList(List<string> listBox)
        {
            IntPtr hHDD = CreateFile(DRIVE_NAME, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero,
            OPEN_EXISTING, 0, IntPtr.Zero);
            if (hHDD != (IntPtr)INVALID_HANDLE_VALUE)
                try
                {

                    STORAGE_PROPERTY_QUERY propertyQuery = new STORAGE_PROPERTY_QUERY();
                    propertyQuery.PropertyId = STORAGE_PROPERTY_ID.StorageDeviceProperty;
                    propertyQuery.QueryType = STORAGE_QUERY_TYPE.PropertyStandardQuery;
                    int querySize = Marshal.SizeOf(typeof(STORAGE_PROPERTY_QUERY));
                    IntPtr pointerQuery = Marshal.AllocHGlobal(querySize);
                    Marshal.StructureToPtr(propertyQuery, pointerQuery, true);
                    const int RESULT_SIZE = 1024;
                    IntPtr pointerResult = Marshal.AllocHGlobal(RESULT_SIZE);
                    int bytesReturned;
                    DeviceIoControl(hHDD, IOCTL_STORAGE_QUERY_PROPERTY, pointerQuery, querySize,
                    pointerResult, RESULT_SIZE, out bytesReturned, IntPtr.Zero);
                    STORAGE_DEVICE_DESCRIPTOR descriptor = (STORAGE_DEVICE_DESCRIPTOR)Marshal.PtrToStructure(pointerResult, typeof(STORAGE_DEVICE_DESCRIPTOR));
                    int baseAddress = pointerResult.ToInt32();
                    string vendorID = string.Empty;
                    if (descriptor.VendorIdOffset != 0)
                        vendorID = Marshal.PtrToStringAnsi((IntPtr)(baseAddress + descriptor.VendorIdOffset));
                    string productID = string.Empty;
                    if (descriptor.ProductIdOffset != 0)
                        productID = Marshal.PtrToStringAnsi((IntPtr)(baseAddress + descriptor.ProductIdOffset));
                    string revision = string.Empty;
                    if (descriptor.ProductRevisionOffset != 0)
                        revision = Marshal.PtrToStringAnsi((IntPtr)(baseAddress + descriptor.ProductRevisionOffset));
                    string serialNumber = string.Empty;
                    if (descriptor.SerialNumberOffset != 0)
                        serialNumber = FlipAndCodeBytes(Marshal.PtrToStringAnsi((IntPtr)(baseAddress + descriptor.SerialNumberOffset)));
                    Marshal.FreeHGlobal(pointerResult);
                    Marshal.FreeHGlobal(pointerQuery);
                    if (vendorID != string.Empty)
                        listBox.Add("VendorID: " + vendorID);
                    if (productID != string.Empty)
                        listBox.Add("ProductID: " + productID);
                    if (revision != string.Empty)
                        listBox.Add("Revision: " + revision);
                    if (serialNumber != string.Empty)
                        listBox.Add("Serial number: " + serialNumber);
                }
                finally
                {
                    CloseHandle(hHDD);
                }
        }
        string FlipAndCodeBytes(string source)
        {
            int sourceLength = source.Length;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < sourceLength; i += 4)
            {
                for (int j = 1; j >= 0; j--)
                {
                    int sum = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        sum *= 16;
                        switch (source[i + j * 2 + k])
                        {
                            case '0': sum += 0; break;
                            case '1': sum += 1; break;
                            case '2': sum += 2; break;
                            case '3': sum += 3; break;
                            case '4': sum += 4; break;
                            case '5': sum += 5; break;
                            case '6': sum += 6; break;
                            case '7': sum += 7; break;
                            case '8': sum += 8; break;
                            case '9': sum += 9; break;
                            case 'a': sum += 10; break;
                            case 'b': sum += 11; break;
                            case 'c': sum += 12; break;
                            case 'd': sum += 13; break;
                            case 'e': sum += 14; break;
                            case 'f': sum += 15; break;
                        }
                    }
                    if (sum > 0)
                        result.Append((char)sum);
                }
            }
            return result.ToString();
        }

        [DllImport("Kernel32.dll")]
        static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode,
        IntPtr lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes,
        IntPtr hTemplateFile);
        [DllImport("Kernel32.dll")]
        static extern bool CloseHandle(IntPtr hObject);
        [DllImport("Kernel32.dll")]
        static extern bool DeviceIoControl(IntPtr hDevice, int dwIoControlCode, IntPtr lpInBuffer, int nInBufferSize,
        IntPtr lpOutBuffer, int nOutBufferSize, out int lpBytesReturned, IntPtr lpOverlapped);
        [StructLayout(LayoutKind.Sequential)]
        struct STORAGE_DEVICE_DESCRIPTOR
        {
            public uint Version;
            public uint Size;
            public char DeviceType;
            public char DeviceTypeModifier;
            public byte RemovableMedia;
            public byte CommandQueueing;
            public uint VendorIdOffset;
            public uint ProductIdOffset;
            public uint ProductRevisionOffset;
            public uint SerialNumberOffset;
            public STORAGE_BUS_TYPE BusType;
            public uint RawPropertiesLength;
            public IntPtr RawDeviceProperties;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct STORAGE_PROPERTY_QUERY
        {
            public STORAGE_PROPERTY_ID PropertyId;
            public STORAGE_QUERY_TYPE QueryType;
            public IntPtr AdditionalParameters;
        }
        enum STORAGE_PROPERTY_ID
        {
            StorageDeviceProperty,
            StorageAdapterProperty
        }
        enum STORAGE_QUERY_TYPE
        {
            PropertyStandardQuery,
            PropertyExistsQuery,
            PropertyMaskQuery,
            PropertyQueryMaxDefined
        }
        enum STORAGE_BUS_TYPE
        {
            BusTypeUnknown,
            BusTypeScsi,
            BusTypeAtapi,
            BusTypeAta,
            BusType1394,
            BusTypeSsa,
            BusTypeFibre,
            BusTypeUsb,
            BusTypeRAID,
            BusTypeMaxReserved = 0x7F
        }

        const int IOCTL_STORAGE_QUERY_PROPERTY = 0x002d1400;
        const uint GENERIC_READ = 0x80000000;
        const int FILE_SHARE_READ = 0x00000001;
        const int FILE_SHARE_WRITE = 0x00000002;
        const int OPEN_EXISTING = 3;
        const int INVALID_HANDLE_VALUE = -1;
    }
}
