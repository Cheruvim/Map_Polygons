# Map_Polygons
В файле "Map area" находится код Windows form, которая включает в себя:
- Карту Google map
- Сохранение изображения, показываемого на карте в png файл
- Кнопка, отвечающая за построение полигонов(на данный момент при нажатии кнопки отметится полигон, который внесен в код в ручную)
- Поля для ввода названия искомого обьекта и точности построения полигона(на данный момент не используемые)

В файле "TestJson" находится код для конвертации json данных в код для C#. Планирую сюда добавить парсинг с сайта "https://nominatim.openstreetmap.org/search?format=json&q=ЗАПРОС&polygon_geojson=1", где текст "ЗАПРОС" необходимо заменять на искомый обьект. После добавления данного функционала вставить данный код в основной проект на событие нажатия кнопки "Area".

