自定義的Log4net Appender
此版包含一個TextBoxAppender可將Log訊息寫入C# RichTextBox套件,使用上RichTextBox所屬的Form必須調用Show()方法,如此Appender才能透過Application.OpenForms找到這個Form進而寫入RichTextBox

Log4net Config

使用如下範例

    <appender name="textBoxAppender" type="Log4netAppender.TextBoxAppender">

      <formName value="xxx"/>

      <textBoxName value="xxx"/>

    </appender>