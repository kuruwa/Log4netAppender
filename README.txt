�۩w�q��Log4net Appender
�����]�t�@��TextBoxAppender�i�NLog�T���g�JRichTextBox�M��,�ϥΤWRichTextBox���ݪ�Form�����ե�Show()��k,�p��Appender�~��z�LApplication.OpenForms���o��Form�i�Ӽg�JRichTextBox


Log4net Config�ϥΦp�U�d��
    <appender name="textBoxAppender" type="Log4netAppender.TextBoxAppender">
      <formName value="Form1"/>
      <textBoxName value="message"/>
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date [%thread] %level - %message%n"/>
      </layout>
    </appender>