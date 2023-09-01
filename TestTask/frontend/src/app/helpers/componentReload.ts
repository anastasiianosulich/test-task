import { Router } from '@angular/router';

export function reloadComponent(router: Router) {
  router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
    router.navigate([router.url]);
  });
}
