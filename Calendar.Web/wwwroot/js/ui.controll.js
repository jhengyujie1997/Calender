(function ($) {
    /***
    * 控制物件
    * @param {string} names 物件名稱
    * @param {string} tag 物件tag名稱有值時，name等於value
    ***/
    $.fn.getControll = function (names, tag) {
        tag = tag || '*'; //如果沒有提供標籤，默認使用 '*'

        // 如果 names 是字符串，將其轉換為數組
        if (typeof names === 'string') {
            names = names.split(',').map(function (name) {
                return name.trim();
            });
        }

        var selectors = names.map(function (name) {
            return tag === '*' ? '[name="' + name + '"]' : '[' + tag + '="' + name + '"]';
        });

        // 在當前上下文中查找並返回匹配的元素
        return this.find(selectors.join(','));
    };

    /***
    * 控制物件
    * @param {string} url - 請求的URL
    * @param {string} key - 下拉Key值
    * @param {Object} params - object物件
    * @param {boolean} pleaseSelect - 是否包含"請選擇"選項，默認為 true
    * @param {boolean} cache - 是否緩存請求结果，默認為 false
    ***/
    $.fn.addSelect = function (url, key, params, pleaseSelect, cache) {
        if (typeof params !== 'object' || params === null || params === undefined) {            
            params = {};
        }
        let self = $(this);
        pleaseSelect = typeof pleaseSelect === 'boolean' ? pleaseSelect : true;
        cache = typeof cache === 'boolean' ? cache : false;
        
        $.ajax({
            url: url,
            method: 'POST',
            data: JSON.stringify({ key: key, paramsObj: params, pleaseSelect: pleaseSelect }), // 將 key、params 和 pleaseSelect 作為請求參數
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: cache, // 控制是否緩存請求结果
            success: function (response) {
                self.html(response.d);
            },
            error: function (xhr, status, error) {
                console.error('Ajax request failed:', error);
            }
        });
    };

	// 定义插件
	$.fn.formInitial = function () {
		var $form = this;
		var handlers = {}; // 使用对象而不是数组来存储处理程序
		var ajaxUrl = '';

		// 定义callDatabus方法
		$form.callDatabus = function (url, formData) {
			ajaxUrl = url;

			// 发送 AJAX 请求
			$.ajax({
				type: 'POST',
				url: ajaxUrl,
				data: formData,
				success: function (response) {
					// 根据url调用相应的处理程序
					if (handlers[url]) {
						handlers[url](response);
					}
				},
				error: function (xhr, status, error) {
					console.error('There was an error: ' + error);
				}
			});

			return $form; // 支持链式调用
		};

		// 定义addHandler方法
		$form.addHandler = function (url, callback) {
			handlers[url] = callback;
			return $form; // 支持链式调用
		};

		return $form;
	};

	// 定義一個事件存儲結構
	var eventHandlers = {};

	// 擴展 jQuery 來添加 addHandler 方法
	$.fn.addHandler = function (eventName, handler) {
		var formId = this.attr('id'); // 獲取表單的 ID
		if (!eventHandlers[formId]) {
			eventHandlers[formId] = {}; // 如果這個表單還沒有任何事件處理器，則初始化
		}
		if (!eventHandlers[formId][eventName]) {
			eventHandlers[formId][eventName] = []; // 如果這個事件還沒有任何處理器，則初始化
		}
		eventHandlers[formId][eventName].push(handler); // 添加事件處理器
	};

	// 擴展 jQuery 來添加 fireHandler 方法
	$.fn.fireHandler = function (eventName, data) {
		var formId = this.attr('id'); // 獲取表單的 ID
		if (eventHandlers[formId] && eventHandlers[formId][eventName]) {
			eventHandlers[formId][eventName].forEach(function (handler) {
				handler(data); // 觸發所有處理器
			});
		}
	};
})(jQuery);