namespace RazorUI.ts播放器;

/// <summary>
///		MpegTSPlayer 的 ts 流源。MpegTSPlayer 将从此对象获取 Stream。
///		Stream 中传输的是 ts 的字节流。
/// </summary>
public interface ITSStreamSource
{
	/// <summary>
	///		获取 ts 流
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<Stream?> GetTSStreamAsync(CancellationToken cancellationToken);
}
