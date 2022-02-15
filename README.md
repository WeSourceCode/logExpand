将log4net封装

使用方法

1.注册log4net.config配置文件
	log4net.config文件提供默认注册机制，需要放到根目录下
	也可使用方法注册 Log.Register("文件地址" as string,是否为相对路径 as bool);
	
2.写入数据库支持sqlserver自动建表检查字段是否存在，sql语句添加数据的字段必须在[]中，表名后面必须为(,方便识别，否则不支持自动建表

3.在写入数据库时添加自定义字段，除在配置文件中配置外，必须调用LogMethod.Properties("key","value") 否则值为空