export class BarChart
{
	/**
	 * 
	 * @param {HTMLDivElement} element
	 */
	static Create(element)
	{
		return new BarChart(element);
	}

	/**
	 * 
	 * @param {HTMLDivElement} element
	 */
	constructor(element)
	{
		this.element = element;
		this.chart = echarts.init(this.element);

		let resizeObserver = new ResizeObserver((entries) =>
		{
			entries.forEach((entry) =>
			{
				console.log('Size changed:', entry.contentRect.width, 'x', entry.contentRect.height);
				this.chart.resize({
					width: entry.contentRect.width,
					height: entry.contentRect.height,
				})
			});
		});

		resizeObserver.observe(this.element);
	}

	Draw()
	{
		// 指定图表的配置项和数据
		var option = {
			title: {
				text: 'ECharts 入门示例'
			},
			tooltip: {},
			legend: {
				data: ['销量']
			},
			xAxis: {
				data: ['衬衫', '羊毛衫', '雪纺衫', '裤子', '高跟鞋', '袜子']
			},
			yAxis: {},
			series: [
				{
					name: '销量',
					type: 'bar',
					data: [5, 20, 36, 10, 10, 20]
				}
			]
		};

		// 使用刚指定的配置项和数据显示图表。
		this.chart.setOption(option);
	}

	Dispose()
	{
		this.chart.dispose();
	}
}
