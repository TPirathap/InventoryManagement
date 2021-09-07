import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchFilter',
  pure: false
})
export class SearchFilterPipe implements PipeTransform {

  transform(items: any[], searchValue: string): any {
    //return null;
  //   if (!items || !callback) {
  //     return items;
  // }
  // // filter items array, items which match and return true will be
  // // kept, false will be filtered out
  // //return items.filter(item => item.title.indexOf(filter.title) !== -1);
  //   return items.filter(item => callback(item));
    if (!items) {
      return [];
    }

      if (!searchValue) {
        return items;
      }

      searchValue = searchValue.toLocaleLowerCase();
      return items.filter(it => {
        return it.ProductName.toLocaleLowerCase().indexOf(searchValue)!=-1 || 
        it.BrandName.toLocaleLowerCase().indexOf(searchValue)!=-1 || 
        it.Label.toLocaleLowerCase().indexOf(searchValue)!=-1 || 
        it.MinimumInventory.toLocaleLowerCase().indexOf(searchValue)!=-1;
      });
    
  }

}
