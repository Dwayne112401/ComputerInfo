using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerInfo
{
    internal static class Computer
    {
        /// <summary>
        /// 操作系统版本
        /// </summary>
        public static string OSDescription { get; } = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
        /// <summary>
        /// 操作系统架构（<see cref="Architecture">）
        /// </summary>
        public static string OSArchitecture { get; } = System.Runtime.InteropServices.RuntimeInformation.OSArchitecture.ToString();
        /// <summary>
        /// 是否为Windows操作系统
        /// </summary>
        public static bool IsOSPlatform { get; } = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows);
        /// <summary>
        /// 计算机名称
        /// </summary>
        public static string ComputerName { get; } = System.Environment.GetEnvironmentVariable("ComputerName");
        /// <summary>
        /// 计算机用户
        /// </summary>
        public static string UserName { get; set; } = System.Environment.UserName;

        /// <summary>
        /// 电脑型号
        // Caption:计算机系统产品
        // Description:计算机系统产品
        // ElementName:
        // IdentifyingNumber:CND0162XZ1
        // InstanceID:
        // Name:HP ENVY x360 Convertible 15-ed0xxx
        // SKUNumber:
        // UUID:A6C31C0E-997C-EA11-8104-B05CDA905B6C
        // Vendor:HP
        // Version:Type1ProductConfigId
        // WarrantyDuration:
        // WarrantyStartDate:
        /// </summary>
        /// <returns></returns>
        public static string GetComputerVersion()
        {
            var version = new StringBuilder();
            var moc = new ManagementClass("Win32_ComputerSystemProduct").GetInstances();
            foreach (ManagementObject mo in moc)
            {
                foreach (var item in mo.Properties)
                {
                    version.Append($"{item.Name}:{item.Value}\r\n");
                }
            }
            return version.ToString(); ;
        }

        /// <summary>
        /// 主板信息
        // Caption:简短说明
        // ConfigOptions:数组，表示位于在底板上跳线和开关的配置
        // CreationClassName:表示类的名称(就是Win32_baseboard类)
        // Depth:对象的描述（底板）
        // Description:基板
        // Height:
        // HostingBoard:如果为TRUE，该卡是一个主板，或在一个机箱中的基板。
        // HotSwappable:如果为TRUE，就是支持热插拔（判断是否支持热插拔）
        // InstallDate:
        // Manufacturer:表示制造商的名称
        // Model:
        // Name:对象的名称标签
        // OtherIdentifyingInfo:
        // PartNumber:
        // PoweredOn:如果为真，物理元素处于开机状态
        // Product:产品的型号
        // Removable:判断是否可拆卸的
        // Replaceable:判断是否可更换的
        // RequirementsDescription:
        // RequiresDaughterBoard:False
        // SerialNumber:制造商分配的用于识别所述物理元件数目
        // SKU:
        // SlotLayout:
        // SpecialRequirements:
        // Status:对象的当前状态
        // Tag:符系统的基板唯一标识
        // Version:08.32
        // Weight:
        // Width:
        /// </summary>
        /// <returns></returns>
        public static string GetBaseBoardInfo()
        {
            var baseBoard = new StringBuilder();
            var moc = new ManagementClass("Win32_BaseBoard").GetInstances();
            foreach (ManagementObject mo in moc)
            {
                foreach (var item in mo.Properties)
                {
                    baseBoard.Append($"{item.Name}:{item.Value}\r\n");
                }
            }
            return baseBoard.ToString();
        }

        /// <summary>
        /// 硬盘驱动器信息（<see cref="https://www.cnblogs.com/zhesong/p/wmiid.html">）
        //  Access:0
        //  Availability:
        //  BlockSize:
        //  Caption:硬盘描述，例如“C:”
        //  Compressed:False
        //  ConfigManagerErrorCode:Windows配置管理器错误代码
        //  ConfigManagerUserConfig:如果为True，该设备使用用户定义的配置
        //  CreationClassName:Win32_LogicalDisk
        //  Description:本地固定磁盘
        //  DeviceID:磁盘驱动器与系统中的其他设备的唯一标识符，例如“C:”
        //  DriveType:3
        //  ErrorCleared:如果为True，报告LastErrorCode错误现已清除
        //  ErrorDescription:关于可能采取的纠正措施记录在LastErrorCode错误，和信息的详细信息
        //  ErrorMethodology:误差检测和校正的类型被此设备支持
        //  FileSystem:NTFS
        //  FreeSpace:可使用硬盘大小
        //  InstallDate:
        //  LastErrorCode:
        //  MaximumComponentLength:255
        //  MediaType:由该设备使用或访问的媒体类型
        //  Name:硬盘名字
        //  NumberOfBlocks:
        //  PNPDeviceID:即插即用逻辑设备的播放设备标识符
        //  PowerManagementCapabilities:
        //  PowerManagementSupported:
        //  ProviderName:
        //  Purpose:
        //  QuotasDisabled:True
        //  QuotasIncomplete:False
        //  QuotasRebuilding:False
        //  Size:硬盘总大小
        //  Status:对象的当前状态
        //  StatusInfo:逻辑设备的状态
        //  SupportsDiskQuotas:True
        //  SupportsFileBasedCompression:True
        //  SystemCreationClassName:Win32_ComputerSystem
        //  SystemName:DESKTOP-OLA70V5
        //  VolumeDirty:False
        //  VolumeName:Windows
        //  VolumeSerialNumber:硬盘的序列号
        /// </summary>
        /// <returns></returns>
        public static string GetDiskInfo()
        {
            var disk = new StringBuilder();
            var moc = new ManagementClass("Win32_LogicalDisk").GetInstances();
            foreach (ManagementObject mo in moc)
            {
                foreach (var item in mo.Properties)
                {
                    disk.Append($"{item.Name}:{item.Value}\r\n");
                }
            }
            return disk.ToString();
        }

        /// <summary>
        /// 处理器信息（<see cref="https://www.cnblogs.com/zhesong/p/wmiid.html">）
        //  AddressWidth:在32位操作系统，该值是32，在64位操作系统是64
        //  Architecture:所使用的平台的处理器架构
        //  AssetTag:代表该处理器的资产标签
        //  Availability:设备的状态
        //  Caption:设备的简短描述
        //  Characteristics:处理器支持定义的功能
        //  ConfigManagerErrorCode:Windows API的配置管理器错误代码
        //  ConfigManagerUserConfig:如果为TRUE，该装置是使用用户定义的配置
        //  CpuStatus:处理器的当前状态
        //  CreationClassName:出现在用来创建一个实例继承链的第一个具体类的名称
        //  CurrentClockSpeed:处理器的当前速度，以MHz为单位
        //  CurrentVoltage:处理器的电压。如果第八位被设置，位0-6包含电压乘以10，如果第八位没有置位，则位在VoltageCaps设定表示的电压值。 CurrentVoltage时SMBIOS指定的电压值只设置
        //  DataWidth:在32位处理器，该值是32，在64位处理器是64
        //  Description:描述
        //  DeviceID:在系统上的处理器的唯一标识符
        //  ErrorCleared:如果为真，报上一个错误代码的被清除
        //  ErrorDescription:错误的代码描述
        //  ExtClock:外部时钟频率，以MHz为单位
        //  Family:处理器系列类型
        //  InstallDate:安装日期
        //  L2CacheSize:二级缓存大小
        //  L2CacheSpeed:二级缓存处理器的时钟速度
        //  L3CacheSize:三级缓存大小
        //  L3CacheSpeed:三级缓存处理器的时钟速度
        //  LastErrorCode:报告的逻辑设备上一个错误代码
        //  Level:处理器类型的定义。该值取决于处理器的体系结构
        //  LoadPercentage:每个处理器的负载能力，平均到最后一秒
        //  Manufacturer:处理器的制造商
        //  MaxClockSpeed:处理器的最大速度，以MHz为单位
        //  Name:处理器的名称
        //  NumberOfCores:处理器的当前实例的数目。核心是在集成电路上的物理处理器
        //  NumberOfEnabledCore:每个处理器插槽启用的内核数
        //  NumberOfLogicalProcessors:用于处理器的当前实例逻辑处理器的数量
        //  OtherFamilyDescription:处理器系列类型
        //  PartNumber:这款处理器的产品编号制造商所设置
        //  PNPDeviceID:即插即用逻辑设备的播放设备标识符
        //  PowerManagementCapabilities:逻辑设备的特定功率相关的能力阵列
        //  PowerManagementSupported:如果为TRUE，该装置的功率可以被管理，这意味着它可以被放入挂起模式
        //  ProcessorId:描述处理器功能的处理器的信息
        //  ProcessorType:处理器的主要功能
        //  Revision:系统修订级别取决于体系结构
        //  Role:所述处理器的作用
        //  SecondLevelAddressTranslationExtensions:如果为True，该处理器支持用于虚拟地址转换扩展
        //  SerialNumber:处理器的序列号
        //  SocketDesignation:芯片插座的线路上使用的类型
        //  Status:对象的当前状态
        //  StatusInfo:对象的当前状态信息
        //  Stepping:在处理器家族处理器的版本
        //  SystemCreationClassName:创建类名属性的作用域计算机的价值
        //  SystemName:系统的名称
        //  ThreadCount:每个处理器插槽的线程数
        //  UniqueId:全局唯一标识符的处理器
        //  UpgradeMethod:CPU插槽的信息
        //  Version:依赖于架构处理器的版本号
        //  VirtualizationFirmwareEnabled:如果真，固件可以虚拟化扩展
        //  VMMonitorModeExtensions:如果为True，该处理器支持Intel或AMD虚拟机监控器扩展。
        //  VoltageCaps:该处理器的电压的能力
        /// </summary>
        /// <returns></returns>
        public static string GetCPUInfo()
        {
            var cpu = new StringBuilder();
            var moc = new ManagementClass("Win32_Processor").GetInstances();
            foreach (var mo in moc)
            {
                foreach (var item in mo.Properties)
                {
                    cpu.Append($"{item.Name}:{item.Value}\r\n");
                }
            }
            return cpu.ToString();
        }

        /// <summary>
        /// 内存信息（<see cref="https://www.cnblogs.com/zhesong/p/wmiid.html">）
        //  Attributes:1
        //  BankLabel:BANK 2
        //  Capacity:获取内存容量（单位KB）
        //  Caption:物理内存还虚拟内存
        //  ConfiguredClockSpeed:配置时钟速度
        //  ConfiguredVoltage:配置电压
        //  CreationClassName:创建类名
        //  DataWidth:获取内存带宽
        //  Description:描述
        //  DeviceLocator:获取设备定位器
        //  FormFactor:构成因素
        //  HotSwappable:是否支持热插拔
        //  InstallDate:安装日期
        //  InterleaveDataDepth:数据交错深度
        //  InterleavePosition:数据交错的位置
        //  Manufacturer:生产商
        //  MaxVoltage:最大电压
        //  MemoryType:内存类型
        //  MinVoltage:最小电压
        //  Model:型号
        //  Name:名字
        //  OtherIdentifyingInfo:其他识别信息
        //  PartNumber:零件编号
        //  PositionInRow:行位置
        //  PoweredOn:是否接通电源
        //  Removable:是否可拆卸
        //  Replaceable:是否可更换
        //  SerialNumber:编号
        //  SKU:SKU号
        //  SMBIOSMemoryType:SMBIOS内存类型
        //  Speed:速率
        //  Status:状态
        //  Tag:唯一标识符的物理存储器
        //  TotalWidth:总宽
        //  TypeDetail:类型详细信息
        //  Version:版本信息
        //  AvailableBytes:可利用内存大小（B）
        //  AvailableKBytes:可利用内存大小（KB）
        //  AvailableMBytes:可利用内存大小（MB）
        //  CacheBytes:125460480
        //  CacheBytesPeak:392294400
        //  CacheFaultsPersec:70774721
        //  Caption:
        //  CommitLimit:31939616768
        //  CommittedBytes:20280020992
        //  DemandZeroFaultsPersec:759274721
        //  Description:
        //  FreeAndZeroPageListBytes:2097152
        //  FreeSystemPageTableEntries:12528527
        //  Frequency_Object:0
        //  Frequency_PerfTime:10000000
        //  Frequency_Sys100NS:10000000
        //  LongTermAverageStandbyCacheLifetimes:14400
        //  ModifiedPageListBytes:41500672
        //  Name:
        //  PageFaultsPersec:1560432075
        //  PageReadsPersec:19173703
        //  PagesInputPersec:98834167
        //  PagesOutputPersec:25921396
        //  PagesPersec:124755563
        //  PageWritesPersec:103362
        //  PercentCommittedBytesInUse:2727084283
        //  PercentCommittedBytesInUse_Base:4294967295
        //  PoolNonpagedAllocs:0
        //  PoolNonpagedBytes:798519296
        //  PoolPagedAllocs:0
        //  PoolPagedBytes:709898240
        //  PoolPagedResidentBytes:496873472
        //  StandbyCacheCoreBytes:247545856
        //  StandbyCacheNormalPriorityBytes:847036416
        //  StandbyCacheReserveBytes:0
        //  SystemCacheResidentBytes:125460480
        //  SystemCodeResidentBytes:0
        //  SystemCodeTotalBytes:0
        //  SystemDriverResidentBytes:17592179236864
        //  SystemDriverTotalBytes:16953344
        //  Timestamp_Object:0
        //  Timestamp_PerfTime:5838028983825
        //  Timestamp_Sys100NS:132532052633540000
        //  TransitionFaultsPersec:792343233
        //  TransitionPagesRePurposedPersec:78554340
        //  WriteCopiesPersec:17253788
        /// </summary>
        /// <returns></returns>
        public static string GetRAMInfo()
        {
            var ram = new StringBuilder();
            var searcher = new ManagementObjectSearcher()
            {
                Query = new SelectQuery("Win32_PhysicalMemory"),
            }.Get().GetEnumerator();

            while (searcher.MoveNext())
            {
                ManagementBaseObject baseObj = searcher.Current;
                foreach (var item in baseObj.Properties)
                {
                    ram.Append($"{item.Name}:{item.Value}\r\n");
                }
            }

            searcher = new ManagementObjectSearcher()
            {
                Query = new SelectQuery("Win32_PerfRawData_PerfOS_Memory"),
            }.Get().GetEnumerator();

            while (searcher.MoveNext())
            {
                ManagementBaseObject baseObj = searcher.Current;
                foreach (var item in baseObj.Properties)
                {
                    ram.Append($"{item.Name}:{item.Value}\r\n");
                }
            }
            return ram.ToString();
        }

        /// <summary>
        /// 显卡信息
        //  AcceleratorCapabilities:
        //  AdapterCompatibility:Intel Corporation
        //  AdapterDACType:Internal
        //  AdapterRAM:1073741824
        //  Availability:3
        //  CapabilityDescriptions:
        //  Caption:Intel(R) UHD Graphics
        //  ColorTableEntries:
        //  ConfigManagerErrorCode:0
        //  ConfigManagerUserConfig:False
        //  CreationClassName:Win32_VideoController
        //  CurrentBitsPerPixel:32
        //  CurrentHorizontalResolution:1920
        //  CurrentNumberOfColors:4294967296
        //  CurrentNumberOfColumns:0
        //  CurrentNumberOfRows:0
        //  CurrentRefreshRate:60
        //  CurrentScanMode:4
        //  CurrentVerticalResolution:1080
        //  Description:Intel(R) UHD Graphics
        //  DeviceID:VideoController1
        //  DeviceSpecificPens:
        //  DitherType:0
        //  DriverDate:20200109000000.000000-000
        //  DriverVersion:26.20.100.7755
        //  ErrorCleared:
        //  ErrorDescription:
        //  ICMIntent:
        //  ICMMethod:
        //  InfFilename:oem41.inf
        //  InfSection:iCML_w10_DS
        //  InstallDate:
        //  InstalledDisplayDrivers:C:\windows\System32\DriverStore\FileRepository\iigd_dch.inf_amd64_d512f7a0dbcb7a2f\igdumdim64.dll,C:\windows\System32\DriverStore\FileRepository\iigd_dch.inf_amd64_d512f7a0dbcb7a2f\igd10iumd64.dll,C:\windows\System32\DriverStore\FileRepository\iigd_dch.inf_amd64_d512f7a0dbcb7a2f\igd10iumd64.dll,C:\windows\System32\DriverStore\FileRepository\iigd_dch.inf_amd64_d512f7a0dbcb7a2f\igd12umd64.dll
        //  LastErrorCode:
        //  MaxMemorySupported:
        //  MaxNumberControlled:
        //  MaxRefreshRate:75
        //  MinRefreshRate:50
        //  Monochrome:False
        //  Name:Intel(R) UHD Graphics
        //  NumberOfColorPlanes:
        //  NumberOfVideoPages:
        //  PNPDeviceID:PCI\VEN_8086&DEV_9B41&SUBSYS_8757103C&REV_02\3&11583659&2&10
        //  PowerManagementCapabilities:
        //  PowerManagementSupported:
        //  ProtocolSupported:
        //  ReservedSystemPaletteEntries:
        //  SpecificationVersion:
        //  Status:OK
        //  StatusInfo:
        //  SystemCreationClassName:Win32_ComputerSystem
        //  SystemName:DESKTOP-OLA70V5
        //  SystemPaletteEntries:
        //  TimeOfLastReset:
        //  VideoArchitecture:5
        //  VideoMemoryType:2
        //  VideoMode:
        //  VideoModeDescription:屏幕描述
        //  VideoProcessor:Intel(R) UHD Graphics Family
        //  AcceleratorCapabilities:
        //  AdapterCompatibility:NVIDIA
        //  AdapterDACType:Integrated RAMDAC
        //  AdapterRAM:4293918720
        //  Availability:8
        //  CapabilityDescriptions:
        //  Caption:显卡描述
        //  ColorTableEntries:
        //  ConfigManagerErrorCode:0
        //  ConfigManagerUserConfig:False
        //  CreationClassName:Win32_VideoController
        //  CurrentBitsPerPixel:
        //  CurrentHorizontalResolution:
        //  CurrentNumberOfColors:
        //  CurrentNumberOfColumns:
        //  CurrentNumberOfRows:
        //  CurrentRefreshRate:
        //  CurrentScanMode:
        //  CurrentVerticalResolution:
        //  Description:NVIDIA GeForce MX330
        //  DeviceID:VideoController2
        //  DeviceSpecificPens:
        //  DitherType:
        //  DriverDate:20200923000000.000000-000
        //  DriverVersion:27.21.14.5241
        //  ErrorCleared:
        //  ErrorDescription:
        //  ICMIntent:
        //  ICMMethod:
        //  InfFilename:oem123.inf
        //  InfSection:Section043
        //  InstallDate:
        //  InstalledDisplayDrivers:C:\windows\System32\DriverStore\FileRepository\nvhm.inf_amd64_c87780efe1918cc5\nvldumdx.dll,C:\windows\System32\DriverStore\FileRepository\nvhm.inf_amd64_c87780efe1918cc5\nvldumdx.dll,C:\windows\System32\DriverStore\FileRepository\nvhm.inf_amd64_c87780efe1918cc5\nvldumdx.dll,C:\windows\System32\DriverStore\FileRepository\nvhm.inf_amd64_c87780efe1918cc5\nvldumdx.dll
        //  LastErrorCode:
        //  MaxMemorySupported:
        //  MaxNumberControlled:
        //  MaxRefreshRate:
        //  MinRefreshRate:
        //  Monochrome:False
        //  Name:NVIDIA GeForce MX330
        //  NumberOfColorPlanes:
        //  NumberOfVideoPages:
        //  PNPDeviceID:PCI\VEN_10DE&DEV_1D16&SUBSYS_8757103C&REV_A1\4&24375CB2&0&00E0
        //  PowerManagementCapabilities:
        //  PowerManagementSupported:
        //  ProtocolSupported:
        //  ReservedSystemPaletteEntries:
        //  SpecificationVersion:
        //  Status:OK
        //  StatusInfo:
        //  SystemCreationClassName:Win32_ComputerSystem
        //  SystemName:DESKTOP-OLA70V5
        //  SystemPaletteEntries:
        //  TimeOfLastReset:
        //  VideoArchitecture:5
        //  VideoMemoryType:2
        //  VideoMode:
        //  VideoModeDescription:
        //  VideoProcessor:GeForce MX330
        /// </summary>
        /// <returns></returns>
        public static string GetGPUInfo()
        {
            var gpu = new StringBuilder();
            var moc = new ManagementObjectSearcher("select * from Win32_VideoController").Get();

            foreach (var mo in moc)
            {
                foreach (var item in mo.Properties)
                {
                    gpu.Append($"{item.Name}:{item.Value}\r\n");
                }
            }
            return gpu.ToString(); ;
        }
    }
}
