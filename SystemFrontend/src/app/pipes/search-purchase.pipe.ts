import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchPurchase'
})
export class SearchPurchasePipe implements PipeTransform {

  transform(items: any[], searchPurch: string): any {

    if (!items) {
      return [];
    }

      if (!searchPurch) {
        return items;
      }

      searchPurch = searchPurch.toLocaleLowerCase();
      return items.filter(it => {
        return it.ProductName.toLocaleLowerCase().indexOf(searchPurch)!=-1 || 
        it.SupplierFirstName.toLocaleLowerCase().indexOf(searchPurch)!=-1 || 
        it.SupplierLastName.toLocaleLowerCase().indexOf(searchPurch)!=-1 || 
        it.StatusDetail.toLocaleLowerCase().indexOf(searchPurch)!=-1;
      });
    
  }

}
