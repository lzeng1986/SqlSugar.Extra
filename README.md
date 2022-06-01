# SqlSugar.Extra
SqlSugar扩展功能，支持FluentAPI配置，多库操作
# 如何使用
## 关键类型
- SqlSugarConfig：数据库配置，可配置连接字符串，使用FluentAPI方式配置表和字段
- ISqlSugarHost<TConnection>：使用数据库，通过IOC方式注入
## 示例
- 定义数据库配置
··· public class TestDBConfig : SqlSugarConfig···
    
