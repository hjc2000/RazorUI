using System.Text.Json.Serialization;

namespace RazorUI.ts播放器;

/// <summary>
///		媒体数据源
/// </summary>
public struct MediaDataSource
{
	/// <summary>
	/// 
	/// </summary>
	public MediaDataSource() { }

	/// <summary>
	/// 
	/// </summary>
	/// <param name="url"></param>
	/// <param name="is_live"></param>
	public MediaDataSource(string url, bool is_live)
	{
		Url = url;
		IsLive = is_live;
	}

	/// <summary>
	///		视频类型
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; set; } = "mpegts";

	/// <summary>
	///		是否是直播
	/// </summary>
	[JsonPropertyName("isLive")]
	public bool IsLive { get; set; } = true;

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("cors")]
	public bool Cors { get; set; } = true;

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("withCredentials")]
	public bool? WithCookies { get; set; } = null;

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("hasVideo")]
	public bool HasVideo { get; set; } = true;

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("hasAudio")]
	public bool HasAudio { get; set; } = true;

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("duration")]
	public double? Duration { get; set; } = null;

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("filesize")]
	public double? FileSize { get; set; } = null;

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("url")]
	public string? Url { get; set; } = null;
}
