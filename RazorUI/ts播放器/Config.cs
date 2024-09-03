using System.Text.Json.Serialization;

namespace RazorUI.ts播放器;

/// <summary>
///		ts 播放器配置
/// </summary>
public struct Config
{
	/// <summary>
	///		ts 播放器配置
	/// </summary>
	public Config() { }

	/// <summary>
	///		使能 service worker
	/// </summary>
	[JsonPropertyName("enableWorker")]
	public bool EnableWorker { get; set; } = true;

	/// <summary>
	///		使用 MSE
	/// </summary>
	[JsonPropertyName("enableWorkerForMSE")]
	public bool EnableWorkerForMSE { get; set; } = true;

	/// <summary>
	///		使用缓存
	/// </summary>
	[JsonPropertyName("enableStashBuffer")]
	public bool EnableStashBuffer { get; set; } = false;

	/// <summary>
	///		缓存初始大小
	/// </summary>
	[JsonPropertyName("stashInitialSize")]
	public double StashInitialSize { get; set; } = 64;

	/// <summary>
	///		直播流延迟追赶
	/// </summary>
	[JsonPropertyName("liveBufferLatencyChasing")]
	public bool LiveBufferLatencyChasing { get; set; } = false;

	/// <summary>
	///		在暂停播放时追赶直播流延迟
	/// </summary>
	[JsonPropertyName("liveBufferLatencyChasingOnPaused")]
	public bool? LiveBufferLatencyChasingOnPaused { get; set; } = null;

	/// <summary>
	///		直播流缓冲区最大延迟。
	/// </summary>
	[JsonPropertyName("liveBufferLatencyMaxLatency")]
	public double? LiveBufferLatencyMaxLatency { get; set; } = null;

	/// <summary>
	///		直播流缓冲区要保留的最小延迟
	/// </summary>
	[JsonPropertyName("liveBufferLatencyMinRemain")]
	public double? LiveBufferLatencyMinRemain { get; set; } = null;

	/// <summary>
	///		直播流同步。
	/// </summary>
	[JsonPropertyName("liveSync")]
	public bool LiveSync { get; set; } = false;

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("liveSyncMaxLatency")]
	public double? LiveSyncMaxLatency { get; set; } = null;

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("liveSyncTargetLatency")]
	public double? LiveSyncTargetLatency { get; set; } = null;

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("liveSyncPlaybackRate")]
	public double? LiveSyncPlaybackRate { get; set; } = null;

	/// <summary>
	///		如果有足够的视频数据可以播放，中断 http 连接。
	/// </summary>
	[JsonPropertyName("lazyLoad")]
	public bool LazyLoad { get; set; } = false;

	/// <summary>
	///		源打开后延迟加载
	/// </summary>
	[JsonPropertyName("deferLoadAfterSourceOpen")]
	public bool? DeferLoadAfterSourceOpen { get; set; } = null;

	/// <summary>
	///		自动清理源缓冲区
	/// </summary>
	[JsonPropertyName("autoCleanupSourceBuffer")]
	public bool AutoCleanupSourceBuffer { get; set; } = true;

	/// <summary>
	///		自动清理机制下最大保留的时长
	/// </summary>
	[JsonPropertyName("autoCleanupMaxBackwardDuration")]
	public double AutoCleanupMaxBackwardDuration { get; set; } = 20;

	/// <summary>
	///		自动清理机制下最小保留的时长。
	/// </summary>
	[JsonPropertyName("autoCleanupMinBackwardDuration")]
	public double AutoCleanupMinBackwardDuration { get; set; } = 10;

	/// <summary>
	///		修复大的音频间隙。会填充静音帧。
	/// </summary>
	[JsonPropertyName("fixAudioTimestampGap")]
	public bool FixAudioTimestampGap { get; set; } = false;

	/// <summary>
	///		加速定位
	/// </summary>
	[JsonPropertyName("accurateSeek")]
	public bool? AccurateSeek { get; set; } = null;

	/// <summary>
	///		可以选择 range 或 param。
	/// </summary>
	[JsonPropertyName("seekType")]
	public string SeekType { get; set; } = "range";

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("seekParamStart")]
	public string? SeekParamStart { get; set; } = null;

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("seekParamEnd")]
	public string? SeekParamEnd { get; set; } = null;

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("rangeLoadZeroStart")]
	public bool? RangeLoadZeroStart { get; set; } = null;
}
