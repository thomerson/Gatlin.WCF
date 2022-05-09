# Gatlin.WCF

WCF 后端基础框架

1. 能自动读取所有service

命名规则

* 所有的Contract单独编译成Contracts.dll

* 所有实现Contract的realise单独编译成Services.dll

程序会自动读取路径下所有的Services.dll，反射读取每个service对应的contract

2. 根据配置启动服务binding

# Gatlin.WCF.Client
