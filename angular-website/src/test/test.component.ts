import { Component } from '@angular/core';
import { BlogDTO } from 'src/app/dtos/blogs/blogDto';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css'],
})
export class TestComponent {
  constructor(){
    this.GetDeleteData3()
  }
  keyword:string=''
  blogfilltering: string[]=[]
  blogDTOArray: string[] = [
    'The Future of AI: Trends to Watch',
    'Explore the latest trends in AI and what they mean for the future.',
    'How to Start a Tech Blog',
    'A comprehensive guide to starting your own tech blog and building an audience.',
    'Building a Career in Tech',
    'Tips and advice for building a successful career in the tech industry.',
    'Machine Learning: Applications and Trends',
    'Explore the latest applications and trends in machine learning.',
  ];

  GetBlogWithMore15Length():string[]{
    return this.blogDTOArray.filter(x=> x.length >35)
  }
  GetBlogWithAppKeyword():string{
    let item = this.blogDTOArray.find(x=> x.toLowerCase().includes('app'))
    if(item == undefined)
      return 'No Record With App Key word';
    return item
  }
  GetDeleteData():string[]{
    //first and last index   0 - 7
    return this.blogDTOArray.slice(3) //start index - end index 
  }

  GetDeleteData2():string[]{
    //first and last index
    return this.blogDTOArray.splice(3) //start index - element count
  }

  GetDeleteData3(){
    //first and last index
    console.log('For Each ')
    let tempArray :string[]= []
    this.blogDTOArray.forEach((x,index)=>{
      if(!x.toLowerCase().includes('app'))
        tempArray.push(x)
    }) //start index - element count
    this.blogDTOArray = tempArray
    this.blogDTOArray.forEach((x)=>{
      console.log(x)
    })
  }

  QuickFilltering(key:string){
    this.blogfilltering = this.blogDTOArray.filter(x=> x.toLowerCase().includes(key.toLowerCase()))
  }

  
  //isLight: boolean = true;
  //isEnglish: boolean = true;
  //names:string[]=['Jasser','Hamza','Asem','Rafat']
  //arabicText:string=" العديد من الأشكال المتوفرة لنصوص لوريم إيبسوم، لكن الأغلبية قد عانت من التغيير بشكل ما، عن طريق إدخال الفكاهة أو الكلمات العشوائية التي لا تبدو قابلة للتصديق ولو قليلاً. إذا كنت ستستخدم فقرة من نص لوريم إيبسوم، فيجب أن تتأكد من عدم وجود أي شيء محرج مخفي في منتصف النص. تميل جميع مولدات لوريم إيبسوم الموجودة على الإنترنت إلى تكرار أجزاء محددة مسبقًا حسب الضرورة، مما يجعل هذا المولد الحقيقي الأول على الإنترنت. يستخدم قاموسًا يضم أكثر من 200 كلمة لاتينية، بالإضافة إلى مجموعة من هياكل الجمل النموذجية، لإنشاء لوريم إيبسوم الذي يبدو معقولاً. ولذلك فإن لوريم إيبسوم الذي تم إنشاؤه يكون دائمًا خاليًا من التكرار أو الفكاهة المحقونة أو الكلمات غير المميزة وما إلى ذلك."
  //englishText:string="Where can I get some There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc."
  /*toggleTheme() {
    this.isLight = !this.isLight;
  }
  toggleLanguage() {
    this.isEnglish = !this.isEnglish;
  }
  getButtonThemeText():string{
    if(this.isLight){
      return 'Swap To Dark'
    }else{
      return 'Swap To Light'
    }
  }
  getButtonLanguageText():string{
    if(this.isEnglish){
      return 'Swap To Arabic'
    }else{
      return 'Swap To English'
    }
  }*/
}
