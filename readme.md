<h2>
  Рабочее окружение
</h2>
	<div>
	<img src="https://visualstudio.microsoft.com/wp-content/uploads/2021/10/Product-Icon.svg" title="VS" alt="VS" width="40" height="40"/>&nbsp;
	<img src="https://cdn-icons-png.flaticon.com/512/5969/5969059.png" title="Docker" alt="Docker" width="40" height="40"/>&nbsp;
	</div>
	
---

<h2>
	Условия задач
</h2>

### Задача №1:

	Написать консольное приложение, которое выводит фамилию и имя пользователя с id 10, данные взять из публичного API.

### Задача №2:

	1) Необходимо сгруппировать сотрудников по отделу из представленного JSON. 
	
	2) В каждый отдел необходимо добавить поле count, содержащее количество сотрудников в отделе.
	
	3) В каждый отдел необходимо добавить поле avg_hours, содержащее среднюю выработку сотрудников по отделу
	
		a) Если у сотрудника отсутствует поле hours, то такого сотрудника необходимо исключить из подсчета средней выработки.
		
		b) Округление до целого по правилам математики.
		
	4) Поле dept необходимо убрать (значение полей dept должны стать ключами выходного json).
	
	5) Вывести сотрудников сгруппированных по отдел.
	
### Задача №3:

	1) Докеризировать оба приложения
	
	2) Если программа содержит этап компиляции, то сделать двухэтапную сборку
	
	3) Описать docker-compose file, в котором должен вызываться написанный вами Dockerfile

---

<h2>
	Инструкция по запуску
</h2>

Для каждой задачи прикреплена ссылка на Image с Docker Hub. Также, прикреплены исходные проекты, содержащие внутри "docker-compose.yml" и "dockerfile".
Для запуска проектов можно использовать инструменты Visual Studio, а также инструменты Docker Desktop.

### Задача №1:
	
Docker Hub: 

`docker pull whyhako/task1:latest`

### Задача №2:
	
Docker Hub: 
	
`docker pull whyhako/task2:latest`

---

[![Whyhako's github activity graph](https://activity-graph.herokuapp.com/graph?username=WhyHako)](https://github.com/WhyHako/Software-Engineering)