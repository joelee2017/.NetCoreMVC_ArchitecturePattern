.NetCoreMVC_ArchitecturePattern

參予SkillTree課程相依注入後的練習

從模版網站中抽出 Repository 跟 Service

一、切出 Repository 分離資料存取

二、反轉相依使用 Interface

三、反轉相依 – 邏輯、聚合相依

四、根據不同職責將切開專案

1. 模組化整個專案

2. Entity Framework 的資料存取層

3. 不變動既有程式碼的狀態下加入新特色

   資料存取抽換

   邏輯抽換

五、抽象洩漏，將資料層與展現層使用model 切開

六、新增Mapper工具針對IQueryable

七、調整資料展現層問題、拔掉非同步

八、剩餘其它功能調整資料展現層、拔掉非同步

九、大多數的系統可以切分成三個層面

- Presentation => Controller
- Domain => Service
- Infrastructure => Repository
- 層數超過這個數量都需要謹慎考慮

十、DI Container 注入的共通概念

- 在相依注入前，得先進行相依辨識及管理
- 注入只是一個讓修改更方便的工具而已
- 抽象 -> 實體對應
- 抽象 -> Factory 對應
- Scope
- Composition Root

十一、移動資料回傳層