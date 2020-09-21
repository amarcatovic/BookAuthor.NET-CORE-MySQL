import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  transform(value: any, searchBy: string, ifSearchEmptyDisplayAll: boolean, property: string, property2: string = null): any {
    if(value === undefined){
      return;
    }

    if((value.length === 0 && ifSearchEmptyDisplayAll) || (!searchBy && ifSearchEmptyDisplayAll)){
      return value;
    }

    let returnArray = [];
    for(const searchObject of value){
        const searchObjectProperty = searchObject[property].toLocaleLowerCase();
        let searchObjectProperty2: string = '';
        let searchObjectPropertyCombined: string = '';
        if(property2 !== null){
            searchObjectProperty2 = searchObject[property2].toLocaleLowerCase();
            searchObjectPropertyCombined = (searchObject[property] + ' ' + searchObject[property2]).toLocaleLowerCase();;
        }

      if(searchObjectProperty.includes(searchBy.toLocaleLowerCase()) || 
        searchObjectProperty2.includes(searchBy.toLocaleLowerCase()) || 
        searchObjectPropertyCombined.includes(searchBy.toLocaleLowerCase())){
        returnArray.push(searchObject);
      }
    }

    return returnArray;
  }

}
