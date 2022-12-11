import { async, ComponentFixture, TestBed } from "@angular/core/testing";
import { RouterTestingModule } from "@angular/router/testing";
import {
  ActivatedRoute,
  UrlSegment,
  convertToParamMap,
  Params,
  Router,
} from "@angular/router";
import { HomeComponent } from "src/app/components/home/home.component";
import { LoginActions } from "../api-authorization.constants";
import { AuthorizeService } from "../authorize.service";
import { LoginComponent } from "./login.component";

class RouterStub {
  url = "";
  navigate(commands: any[], extras?: any) {}
}

describe("LoginComponent", () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let router: Router;

  beforeEach(async(() => {
    const tempParams: Params = { id: "1234" };

    const segment0: UrlSegment = new UrlSegment("segment0", {});
    const segment1: UrlSegment = new UrlSegment(LoginActions.Login, {});

    const urlSegments: UrlSegment[] = [segment0, segment1];

    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule.withRoutes([
          {
            path: "authentication/login-failed",
            component: HomeComponent,
          },
        ]),
      ],
      declarations: [LoginComponent, HomeComponent],
      providers: [
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: {
              paramMap: convertToParamMap(tempParams),
              url: urlSegments,
              queryParams: tempParams,
            },
          },
        },
      ],
    }).compileComponents();

    router = TestBed.get(Router);
    spyOn(router, "navigate").and.returnValue(Promise.resolve(true));
  }));

  beforeEach(() => {
    const authService = TestBed.get(AuthorizeService);

    spyOn(authService, "ensureUserManagerInitialized").and.returnValue(
      Promise.resolve()
    );

    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
