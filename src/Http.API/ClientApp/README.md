# 目录结构
`app`
- components,组件，无路由
  - [ ] layout，**内置**
    - 上下（左右栏）布局
  - [ ] naviagation
    - 两级菜单，**生成**
  - [ ] dialogs
    - deleteConfirmDialog，**内置**
  - 
- pages，页面，带路由
  - 
- share
  - models，**生成**
  - services，**生成**
  - [ ] pipe，**内置**
- auth 授权验证
  - AuthConfigModule, 
  - [ ] AuthGuard, 路由守卫
  
# 依赖
- 字体图标: [`Material Icons`](https://fonts.google.com/icons?selected=Material+Icons)
- 布局: `bootstrap-grid`
- UI: `Angular Material`
- 富文件编辑器：[`ckeditor5`](https://github.com/ckeditor/ckeditor5-angular)
- markdown编辑器：[`ngx-markdown`](https://github.com/jfcere/ngx-markdown)

# 常见业务页面实现
## 页面及组件
- 列表
  - 基本信息和操作控件（新增,筛选）
  - 筛选控件
  - 行内容，控件列...(删除、编辑(弹窗))
  - 批量操作和分页信息
- 新增，页面
- 编辑，弹窗

## 控件类型
- 枚举：`select`，下拉选择
- 字符串(<200): `input text`
- 数字: `input number`
- 字符串(200-1000): `textarea`
- 字符串(>1000): `editor`，文本编辑器
- 引用依赖(非用户)，`select`，下拉选择
- 包含List，选择弹窗(列表多选)，默认注释