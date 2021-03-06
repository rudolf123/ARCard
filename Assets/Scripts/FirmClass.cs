﻿using UnityEngine;
using System.Collections;

public class FirmInfo{
	public FirmInfo(){
		GenerateTemplate ();
	}
	
	public void GenerateTemplate(){
		name = "MyFirm";
		info = "MyFrimIsAwesome";
		partners = "Partners of my firm";
		residents = "Residents of my firm";
		contacts = "Contact of my firm +124135236365";
		logo = "";
	}

	public void GenerateTemplateUdina(){
		name = "Дизайнер Юдина Л.В.";
		info = "Разработка рекламных материалов (дизайн, копирайт) Разработка неймингов, слоганов, брифов Подготовка контента для СМИ и on line ресурсов Сотрудничество с рекламными агентствами SEO продвижение (базовое, соц сети) ";
		partners = "Microsoft, Photoshop, 3DS max";
		residents = "Residents of my firm";
		contacts = "Contact of my firm +124135236365";
		logo = "milaLogo";
	}

	public void GenerateTemplateCMIT(){
		name = "ЦМИТ \"Действуй\"";
		info = "Центр молодежного инновационного творчества ДЕЙСТВУЙ - место воплощения идей и креатива. \n Центр обладает оборудованием для конструирования, моделирования, создания прототипов и готовых изделий. Если у вас есть идея - приходите и воплотите ее в жизнь.";
		partners = "Наши партнеры: \n •Ассоциация бизнес-инкубаторов г. Пензы \n •Правительство г. Пензы";
		residents = "\n •Юдина Л.В.\n •Иванов В.В. \n • Смирнов В.В.";
		contacts = "Позвоните нам по телефону: \n +79378989894";
		logo = "fablabLogo";
	}

	public string Name {
		get {
			return this.name;
		}
		set {
			name = value;
		}
	}
	
	public string Info {
		get {
			return this.info;
		}
		set {
			info = value;
		}
	}
	
	public string Partners {
		get {
			return this.partners;
		}
		set {
			partners = value;
		}
	}
	
	public string Logo {
		get {
			return this.logo;
		}
		set {
			logo = value;
		}
	}
	
	public string Residents {
		get {
			return this.residents;
		}
		set {
			residents = value;
		}
	}
	
	public string Contacts {
		get {
			return this.contacts;
		}
		set {
			contacts = value;
		}
	}
	
	private string name;
	private string info;
	private string partners;
	private string logo;
	private string residents;
	private string contacts;
}
